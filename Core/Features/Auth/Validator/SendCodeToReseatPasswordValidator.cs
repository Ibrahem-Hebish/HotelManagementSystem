using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

public class SendCodeToReseatPasswordValidator : AbstractValidator<SendCodeToReseatPassword>
{
    public SendCodeToReseatPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");
    }
}