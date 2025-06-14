using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetAvilableRooms : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => "Core-Rooms-Offers-Available";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
