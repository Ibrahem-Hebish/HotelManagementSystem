using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetRoomsByArea(decimal MinArea, decimal MaxArea) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Area-{MinArea}-{MaxArea}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
