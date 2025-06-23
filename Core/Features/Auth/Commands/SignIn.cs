using Core.Features.Customers.Dtos;

namespace Core.Features.Auth.Commands;

public sealed record SignIn(string Email, string Password) : IValidatorRequest, IRequest<Response<UserTokenDto>>
{
}
