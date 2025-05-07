using Core.Rooms.Dtos;

namespace Core.Rooms.Queries;

public record GetAllRooms : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => "Core-Rooms";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
