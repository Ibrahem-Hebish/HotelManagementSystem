using System.Linq.Expressions;

namespace Services.SpecificationPattern.ReservationSpecifications;

public class GetExpiredReservationsSpecification : ISpecification<Reservation>
{
    public Expression<Func<Reservation, bool>> Filter
    {
        get => r => r.CheckOutDate < DateTime.UtcNow;
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
