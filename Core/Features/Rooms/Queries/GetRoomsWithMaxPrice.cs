using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record class GetRoomsWithMaxPrice(decimal MaxPrice) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-MaxPrice-{MaxPrice}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
