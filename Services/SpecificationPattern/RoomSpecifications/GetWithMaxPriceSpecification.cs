using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetWithMaxPriceSpecification(decimal maxPrice) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.TotalPrice <= maxPrice;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
