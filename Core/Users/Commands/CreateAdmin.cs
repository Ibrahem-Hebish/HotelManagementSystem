using Core.Mediator.MediatorPipelines.Commands;

namespace Core.Users.Commands;

public sealed class CreateAdmin : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<UserToken>>
{
    public string CachedId => $"Core-Users";
}
