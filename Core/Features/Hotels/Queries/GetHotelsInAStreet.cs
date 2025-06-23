namespace Core.Features.Hotels.Queries;

public sealed record GetHotelsInAStreet(string Street) : IRequest<Response<List<GetHotel>>>
{

}

