using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetRoomsOffersSpecification : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.DiscountPercentage > 0;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
