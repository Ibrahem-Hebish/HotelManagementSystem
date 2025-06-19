using Core.Features.Users.Dtos;

namespace Core.Features.Users.Commands;

public sealed class CreateAdmin : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<GetUser>>
{
    public string CachedId => $"Core-Users";
}
