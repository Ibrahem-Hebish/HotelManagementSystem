using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetByRoomStatusSpecification(RoomStatus roomStatus) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Status == roomStatus;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
