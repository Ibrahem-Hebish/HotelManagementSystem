using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByRoomTypeSpecification(RoomType roomType) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Type == roomType;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }

}
