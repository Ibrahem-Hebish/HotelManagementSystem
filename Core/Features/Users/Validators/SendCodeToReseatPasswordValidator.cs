using Core.Features.Users.Commands;

namespace Core.Features.Users.Validators;

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