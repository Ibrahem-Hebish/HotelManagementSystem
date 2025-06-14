using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByAreaRangeSpecification(decimal minArea, decimal maxArea) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Area >= minArea && room.Area <= maxArea;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
