using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUsersByCity(string City) : IRequest<Response<List<GetUser>>>
{

}
