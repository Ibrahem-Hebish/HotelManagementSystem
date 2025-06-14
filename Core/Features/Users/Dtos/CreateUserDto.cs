using Data.Enums;

namespace Core.Features.Users.Dtos;

public class CreateUserDto : IValidatorRequest
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string ConfirmedPassword { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public UserGender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
}
