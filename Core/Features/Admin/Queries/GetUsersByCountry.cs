using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUsersByCountry(string Country) : IRequest<Response<List<GetUser>>>
{

}
