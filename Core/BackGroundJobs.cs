namespace Core;

public class BackGroundJobs(
           IUnitOfWork unitOfWork,
           IRepository<Room> roomCommandRepository,
           IRoomRepository roomQueryRepository,
           IReservationRepository reservationRepository)
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IRepository<Room> roomCommandRepository = roomCommandRepository;
    private readonly IRoomRepository roomQueryRepository = roomQueryRepository;
    private readonly IReservationRepository reservationRepository = reservationRepository;

    public async Task ReleaseAvillableRooms(CancellationToken cancellationToken)
    {
        var spec = new GetExpiredReservationsSpecification();

        var includeOptions = new ReservationIncludeOptions();

        includeOptions.None();

        var reservations = await reservationRepository.Search(spec, includeOptions, cancellationToken);

        foreach (var reservation in reservations)
        {
            var room = await roomQueryRepository.GetByIdAsync(reservation.RoomId, cancellationToken);

            if (room != null && room.Status == RoomStatus.Reserved)
            {
                room.Status = RoomStatus.Available;
                await roomCommandRepository.UpdateAsync(room, room.Id);
            }
        }

        await unitOfWork.SaveChangesAsync();
    }
}
