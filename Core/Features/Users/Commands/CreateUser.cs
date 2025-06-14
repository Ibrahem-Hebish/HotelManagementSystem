using Core.Features.Users.Dtos;
using Data.Enums;

namespace Core.Features.Users.Commands;
public sealed class CreateUser : CreateUserDto, ICommand, IValidatorRequest, IRequest<Response<UserToken>>
{
    public string CachedId => $"Core-Users";
}



public sealed record PatchUser(
    string Id, string? FirstName, string? LastName, string? UserName,
    string? Email, string? PhoneNumber, UserGender? Gender,
    DateOnly? BirthDate, string? Country, string? City)

    : ICommand, IValidatorRequest, IRequest<Response<string>>
{
    public string CachedId => $"Core-Users";
}