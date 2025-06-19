using Core.Features.Hotels.Dto;

namespace Core.Features.Hotels.Queries;

public sealed record HotelSearch(string? HotelName, string? City, string? Country, string? Street) : IValidatorRequest, IRequest<Response<List<GetHotel>>>
{

}