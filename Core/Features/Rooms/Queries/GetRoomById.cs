using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetRoomById(int Id) : ICachedQuery, IRequest<Response<GetRoom>>
{
    public string CachedId => $"Core-Rooms-{Id}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
