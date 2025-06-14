using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetAvailableRoomsSpecification : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.Status == RoomStatus.Available;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}


