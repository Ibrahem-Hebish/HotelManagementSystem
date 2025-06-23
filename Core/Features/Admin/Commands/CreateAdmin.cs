using Core.Features.Customers.Dtos;

namespace Core.Features.Admin.Commands;

public sealed class CreateAdmin : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<GetUser>>
{
    public string CachedId => $"Core-Users";
}
