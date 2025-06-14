using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetWithMinPriceSpecification(decimal minPrice) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.TotalPrice >= minPrice;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
