using Core.Features.Users.Dtos;

namespace Core.Features.Users.Commands;

public sealed class CreateVendor : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<GetUser>>
{
    public string CachedId => $"Core-Users";
}
