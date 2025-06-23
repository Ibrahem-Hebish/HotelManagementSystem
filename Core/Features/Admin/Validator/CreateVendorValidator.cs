using Core.Features.Customers.Commands;

namespace Core.Features.Admin.Validator;

public class CreateVendorValidator : AbstractValidator<CreateUser>
{
    public CreateVendorValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .WithMessage("First name is required.")
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotNull()
            .WithMessage("Last name is required.")
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.UserName)
            .NotNull()
            .WithMessage("User name is required.")
            .NotEmpty()
            .WithMessage("User name is required.")
            .MaximumLength(50)
            .WithMessage("User name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("Email is required.")
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Password is required.")
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.")
            .Matches("[0-9]")
            .WithMessage("Password must contain at least one digit.")
            .Matches("[A-Z]")
            .WithMessage("Password must contain at least one upper char.");

        RuleFor(x => x.ConfirmedPassword)
        .NotNull()
        .WithMessage("Confirmed password is required.")
        .NotEmpty()
        .WithMessage("Confirmed password is required.")
        .Equal(x => x.Password)
        .WithMessage("Confirmed password must match the password.");

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .WithMessage("Phone number is required.")
            .NotEmpty()
            .WithMessage("Phone number is required.");

        RuleFor(x => x.Country)
            .NotNull()
            .WithMessage("Country is required.")
            .NotEmpty()
            .WithMessage("Country is required.");

        RuleFor(x => x.City)
            .NotNull()
            .WithMessage("City is required.")
            .NotEmpty()
            .WithMessage("City is required.");

        RuleFor(x => x.Gender)
            .NotNull()
            .WithMessage("Gender can not be null")
            .NotEmpty()
            .WithMessage("Gender can not be empty");

        RuleFor(x => x.BirthDate)
           .NotNull()
           .WithMessage("Birth Date can not be null")
           .NotEmpty()
           .WithMessage("Birth Date can not be empty");
    }
}
