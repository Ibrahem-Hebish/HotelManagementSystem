using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetRoomsWithOffer : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => "Core-Rooms-Offer";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
