namespace Core.Features.Users.Commands;

public sealed record ReseatPassword(string Email, string Code, string NewPassword, string ConfirmNewPassword) : IRequest<Response<string>>
{

}
