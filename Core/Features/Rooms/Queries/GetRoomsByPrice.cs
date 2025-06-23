namespace Core.Features.Rooms.Queries;

public record GetRoomsByPrice(decimal MinPrice, decimal MaxPrice) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Price-{MinPrice}-{MaxPrice}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
