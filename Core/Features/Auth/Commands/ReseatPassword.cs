namespace Core.Features.Auth.Commands;

public sealed record ReseatPassword(string Email, string Code, string NewPassword, string ConfirmNewPassword) : IRequest<Response<string>>
{

}
