using Core.Features.Hotels.Dto;

namespace Core.Features.Hotels.Queries;

public sealed record GetHotelById(int Id) : IRequest<Response<GetHotel>>, ICachedQuery
{

    public string CachedId => $"Core-Hotel-{Id}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
