namespace Core.Features.Customers.Commands;

public sealed record PatchUser(
    string Id, string? FirstName, string? LastName, string? UserName,
    string? Email, string? PhoneNumber, UserGender? Gender,
    DateOnly? BirthDate, string? Country, string? City)

    : ICommand, IValidatorRequest, IRequest<Response<string>>
{
    public string CachedId => $"Core-Users";
}