namespace Core.Features.Hotels.Queries;

public sealed record GetHotelsByCountry(string Country) : IRequest<Response<List<GetHotel>>>, ICachedQuery
{
    public string CachedId => $"Core-Hotels-Country-{Country}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}