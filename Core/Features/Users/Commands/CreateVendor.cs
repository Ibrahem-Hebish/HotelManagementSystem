using Core.Features.Users.Dtos;
using Core.Mediator.MediatorPipelines.Commands;

namespace Core.Features.Users.Commands;

public sealed class CreateVendor : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<UserToken>>
{
    public string CachedId => $"Core-Users";
}
