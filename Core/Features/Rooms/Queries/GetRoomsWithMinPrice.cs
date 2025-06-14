using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record class GetRoomsWithMinPrice(decimal MinPrice) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-MinPrice-{MinPrice}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
