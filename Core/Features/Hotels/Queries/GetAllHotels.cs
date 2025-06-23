namespace Core.Features.Hotels.Queries;

public sealed record GetAllHotels : IRequest<Response<List<GetHotel>>>, ICachedQuery
{
    public string CachedId => "Core-Hotels";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}

