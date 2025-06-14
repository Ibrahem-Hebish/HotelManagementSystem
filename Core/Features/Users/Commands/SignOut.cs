namespace Core.Features.Users.Commands;

public sealed record SignOut(string UserId) : ICommand, IRequest<Response<string>>
{
    public string CachedId => $"Core-Users";
}
