namespace Core.Users.Commands;

public sealed record SignIn(string Email, string Password) : IValidatorRequest, IRequest<Response<UserToken>>
{
}
