using Core.Features.Users.Commands;

namespace Core.Features.Users.Validators;

public class CheckIfEmailExsistValidator : AbstractValidator<CheckIfEmailExsist>
{
    public CheckIfEmailExsistValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .NotEmpty()
            .WithMessage("Email is required.");
    }
}