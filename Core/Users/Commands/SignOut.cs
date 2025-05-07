using Core.Mediator.MediatorPipelines.Commands;

namespace Core.Users.Commands;

public sealed record SignOut(string userId) : ICommand, IRequest<Response<string>>
{
    public string CachedId => $"Core-Users";
}
