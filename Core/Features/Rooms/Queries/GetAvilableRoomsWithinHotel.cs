namespace Core.Features.Rooms.Queries;

public record GetAvilableRoomsWithinHotel(int HotelId) : ICachedQuery, IRequest<Response<List<GetRoom>>>
{
    public string CachedId => $"Core-Rooms-Offers-Available-Hotel-{HotelId}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}