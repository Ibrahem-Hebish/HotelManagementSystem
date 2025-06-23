using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Queries;

public sealed record GetUserByPhone(string Phone) : IRequest<Response<GetUser>>
{
}
