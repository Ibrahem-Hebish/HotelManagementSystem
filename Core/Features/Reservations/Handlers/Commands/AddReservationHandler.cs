using Core.Features.Reservations.Commands;

namespace Core.Features.Reservations.Handlers.Commands;

public class AddReservationHandler(
    IRepository<Reservation> repository,
    IReservationRepository reservationRepository,
    UserManager<User> userManager,
    IHotelRepository hotelRepository,
    IRepository<Room> roomCommandRepository,
    IRoomRepository roomRepository,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<AddReservation, Response<bool>>
{
    public async Task<Response<bool>> Handle(AddReservation request, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransaction();

        var hotel = await hotelRepository.GetByIdAsync(request.HotelId, cancellationToken);

        if (hotel is null)
            return NotFouned<bool>($"Hotel with ID {request.HotelId} not found.");

        var room = await roomRepository.GetByIdAsync(request.RoomId, cancellationToken);

        if (room is null)
            return NotFouned<bool>($"Room with ID {request.RoomId} not found in hotel {request.HotelId}.");

        if (room.HotelId != hotel.Id)
            return BadRequest<bool>($"Room {room.Id} does not belong to Hotel {hotel.Id}.");

        if (room.Status != RoomStatus.Available)
            return BadRequest<bool>($"Room {room.Id} is not available for reservation.");

        var user = await userManager.FindByIdAsync(request.CustomerId);

        if (user is null)
            return NotFouned<bool>($"User with ID {request.CustomerId} not found.");

        var hasConflict = await reservationRepository
            .HasConflictAsync(
            request.RoomId, request.CheckInDate,
            request.CheckOutDate, cancellationToken);

        if (hasConflict)
            return BadRequest<bool>("The room is already reserved for the selected dates.");

        var reservation = request.Adapt<Reservation>();

        reservation.TotalPrice = reservationRepository.CalculateReservationPrice(
                                                                      room,
                                                                      reservation.CheckInDate,
                                                                      reservation.CheckOutDate,
                                                                      reservation.FoodServiceType);

        try
        {
            var isCreated = await repository.CreateAsync(reservation, cancellationToken);

            if (!isCreated)
                return InternalServerError<bool>("Failed to create reservation.");

            room.Status = RoomStatus.Reserved;

            await roomCommandRepository.UpdateAsync(room, room.Id);

            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransaction();

            return Success(true, "Reservation created successfully.");
        }
        catch (Exception ex)
        {
            Log.Error("An error occurred while creating the reservation.");

            await unitOfWork.RollBack();

            if (ex is DbUpdateConcurrencyException)
                return BadRequest<bool>("The reservation could not be created because the room was reserved.");

            return InternalServerError<bool>("An error occurred while creating the reservation.");
        }

    }
}
