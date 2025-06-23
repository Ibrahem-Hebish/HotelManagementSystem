using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

public class ConfirmEmailValidator : AbstractValidator<ConfirmEmail>
{
    public ConfirmEmailValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("User Email is not valid.")
            .NotEmpty()
            .WithMessage("User Email is required.")
            .NotNull()
            .WithMessage("User Email is required");

        RuleFor(x => x.Token)
            .NotEmpty()
            .WithMessage("Code is required.")
            .NotNull()
            .WithMessage("Code is required");
    }
}