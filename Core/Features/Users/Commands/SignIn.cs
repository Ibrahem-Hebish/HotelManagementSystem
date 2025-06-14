using Core.Features.Users.Dtos;

namespace Core.Features.Users.Commands;

public sealed record SignIn(string Email, string Password) : IValidatorRequest, IRequest<Response<UserTokenDto>>
{
}
