using Core.Features.Hotels.Dto;

namespace Core.Features.Hotels.Queries;

public sealed record GetHotelsByCity(string City) : IRequest<Response<List<GetHotel>>>, ICachedQuery
{
    public string CachedId => $"Core-Hotels-City-{City}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
