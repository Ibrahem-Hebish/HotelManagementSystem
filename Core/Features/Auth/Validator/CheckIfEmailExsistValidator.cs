using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

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
