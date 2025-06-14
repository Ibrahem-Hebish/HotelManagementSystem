using Core.Features.Rooms.Dtos;

namespace Core.Features.Rooms.Queries;

public record GetHotelOffers(int HotelId) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Offers-Hotel-{HotelId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
