using Core.Features.Reservations.Commands;

namespace Core.Features.Reservations.Handlers.Commands;

public class PatchReservationHandler(
       IRepository<Reservation> commandRepo,
       IReservationRepository queryRepo,
       IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<PatchReservation, Response<bool>>
{
    public async Task<Response<bool>> Handle(PatchReservation request, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransaction();

        if (request.CheckOutDate is null &&
                      request.foodServiceType is null &&
                      request.reservationStatus is null &&
                      request.paymentStatus is null)
            return BadRequest<bool>("At least one field must be provided for update.");

        var reservation = await queryRepo.GetByIdAsync(request.Id, cancellationToken);

        if (reservation is null)
            return NotFouned<bool>($"Reservation with ID {request.Id} not found.");

        if (request.CheckOutDate.HasValue)
        {
            var hasConflict = await queryRepo
                .HasConflictAsync(
                               reservation.RoomId, reservation.CheckInDate,
                               request.CheckOutDate.Value, cancellationToken);
            if (hasConflict)
                return BadRequest<bool>("The room is already reserved for the selected dates.");

            reservation.CheckOutDate = request.CheckOutDate.Value;

            reservation.TotalPrice = queryRepo.CalculateReservationPrice(
                                              reservation.Room, reservation.CheckInDate,
                                              reservation.CheckOutDate, reservation.FoodServiceType);
        }

        if (request.paymentStatus.HasValue)
            reservation.PaymentStatus = request.paymentStatus.Value;

        if (request.reservationStatus.HasValue)
            reservation.Status = request.reservationStatus.Value;

        if (request.foodServiceType.HasValue)
        {
            reservation.FoodServiceType = request.foodServiceType.Value;

            reservation.TotalPrice = queryRepo.CalculateReservationPrice(
                               reservation.Room, reservation.CheckInDate,
                               reservation.CheckOutDate, reservation.FoodServiceType);
        }

        try
        {
            var isUpdated = await commandRepo.UpdateAsync(reservation, reservation.Id);

            if (!isUpdated)
                return InternalServerError<bool>("Failed to update reservation.");

            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransaction();

            return Success(true, "Reservation updated successfully.");
        }
        catch (Exception ex)
        {
            Log.Error("An error occurred while updating the reservation.");

            await unitOfWork.RollBack();

            if (ex is DbUpdateConcurrencyException)
                return BadRequest<bool>("The reservation has been modified by another user. Please reload and try again.");

            return InternalServerError<bool>("An error occurred while updating the reservation.");
        }


    }
}
