using Core.Features.Customers.Dtos;

namespace Core.Features.Customers.Commands;
public sealed class CreateUser : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<GetUser>>
{
    public string CachedId => $"Core-Users";
}
