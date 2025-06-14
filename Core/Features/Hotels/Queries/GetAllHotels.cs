using Core.Features.Hotels.Dto;

namespace Core.Features.Hotels.Queries;

public sealed record GetAllHotels : IRequest<Response<List<GetHotel>>>, ICachedQuery
{
    public string CachedId => "Core-Hotels";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}

public sealed record HotelSearch(string? HotelName, string? City, string? Country, string? Street) : IValidatorRequest, IRequest<Response<List<GetHotel>>>
{

}