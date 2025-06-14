using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByMinAreaSpecification(decimal minArea) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Area >= minArea;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
