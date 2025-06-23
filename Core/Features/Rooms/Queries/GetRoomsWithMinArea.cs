namespace Core.Features.Rooms.Queries;

public record GetRoomsWithMinArea(decimal MinArea) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-MinArea-{MinArea}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
