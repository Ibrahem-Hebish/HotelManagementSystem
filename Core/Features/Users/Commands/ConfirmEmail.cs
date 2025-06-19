namespace Core.Features.Users.Commands;

public sealed record ConfirmEmail(string Email, string Token) : IValidatorRequest, IRequest<Response<bool>>
{
}