using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetRoomsWithMaxArea(decimal MaxArea) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-MaxArea-{MaxArea}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
