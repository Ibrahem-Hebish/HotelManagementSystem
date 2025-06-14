using Core.Features.Rooms.Dtos;
using Data.Enums;

namespace Core.Features.Rooms.Queries;

public record GetRoomsByStatus(RoomStatus Status) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Status-{Status}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
