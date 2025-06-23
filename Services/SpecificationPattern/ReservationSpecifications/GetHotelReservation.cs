using System.Linq.Expressions;

namespace Services.SpecificationPattern.ReservationSpecifications;

public class GetHotelReservationSpecification(int hotelId) : ISpecification<Reservation>
{
    public Expression<Func<Reservation, bool>> Filter
    {
        get =>
            h => h.HotelId == hotelId;

        set => throw new NotImplementedException("Filter is read-only in this specification.");

    }
}
