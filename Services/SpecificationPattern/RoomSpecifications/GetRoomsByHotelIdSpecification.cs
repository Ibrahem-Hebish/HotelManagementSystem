using System.Linq.Expressions;

namespace Services.SpecificationPattern.RoomSpecifications;

public class GetRoomsByHotelIdSpecification(int hotelId) : ISpecification<Room>
{
    public Expression<Func<Room, bool>> Filter
    {
        get
        {
            return room => room.HotelId == hotelId;
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
