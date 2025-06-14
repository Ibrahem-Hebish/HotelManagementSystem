using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetRoomsByHotelId(int HotelId) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Hotel-{HotelId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
