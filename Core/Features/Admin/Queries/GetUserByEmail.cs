using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUserByEmail(string Email) : IRequest<Response<GetUser>>
{
}
