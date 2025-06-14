namespace Core.Features.Users.Commands;

public sealed record SendCodeToReseatPassword(string Email) : IRequest<Response<string>>
{

}
