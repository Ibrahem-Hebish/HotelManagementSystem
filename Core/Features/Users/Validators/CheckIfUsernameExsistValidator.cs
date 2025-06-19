using Core.Features.Users.Commands;

namespace Core.Features.Users.Validators;

public class CheckIfUsernameExsistValidator : AbstractValidator<CheckIfUsernameExsist>
{
    public CheckIfUsernameExsistValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");
    }
}
