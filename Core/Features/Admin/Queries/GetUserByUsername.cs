using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUserByUsername(string Username) : IRequest<Response<GetUser>>
{
}
