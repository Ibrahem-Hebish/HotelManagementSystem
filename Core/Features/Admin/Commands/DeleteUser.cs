namespace Core.Features.Admin.Commands;

public sealed record DeleteUser(string UserId) : ICommand, IValidatorRequest, IRequest<Response<bool>>
{
    public string CachedId => $"Core-Users-{UserId}";
}
