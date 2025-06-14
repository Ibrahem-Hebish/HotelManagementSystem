using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetHotelOffersSpecification(int hotelId) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.HotelId == hotelId && room.DiscountPercentage > 0;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
