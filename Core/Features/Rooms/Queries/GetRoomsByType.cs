using Core.Features.Rooms.Dtos;
using Data.Enums;

namespace Core.Features.Rooms.Queries;

public record GetRoomsByType(RoomType Type) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Type-{Type}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
