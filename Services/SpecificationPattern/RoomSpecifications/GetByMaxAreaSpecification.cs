using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByMaxAreaSpecification(decimal maxArea) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Area <= maxArea;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
