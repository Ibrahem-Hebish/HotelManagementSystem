using Services.SpecificationPattern;
using Services.SpecificationPattern.ReservationSpecifications;

namespace Services.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
    Task<Reservation> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Reservation>> Search(ISpecification<Reservation> spec, ReservationIncludeOptions options, CancellationToken cancellationToken);
    decimal CalculateReservationPrice(Room room, DateTime checkIn, DateTime checkOut, FoodServiceType service);
    Task<bool> HasConflictAsync(int roomId, DateTime checkInDate, DateTime checkOutDate, CancellationToken cancellationToken = default);
}
