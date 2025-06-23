namespace Core.Features.Auth.Commands;

public sealed record SignOut(string UserId, int TokenId) : ICommand, IRequest<Response<string>>
{
    public string CachedId => $"Core-Users";
}
