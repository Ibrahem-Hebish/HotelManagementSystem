using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

public class CheckIfUsernameExsistValidator : AbstractValidator<CheckIfUsernameExsist>
{
    public CheckIfUsernameExsistValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");
    }
}
