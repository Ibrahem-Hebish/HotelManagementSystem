namespace Core.Features.Auth.Commands;

public sealed record SendCodeToReseatPassword(string Email) : IRequest<Response<string>>
{

}
