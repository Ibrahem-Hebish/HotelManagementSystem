using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByAreaSpecification(decimal area) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Area == area;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }

}


