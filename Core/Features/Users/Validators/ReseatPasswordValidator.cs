using Core.Features.Users.Commands;

namespace Core.Features.Users.Validators;

public class ReseatPasswordValidator : AbstractValidator<ReseatPassword>
{
    public ReseatPasswordValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("User Email is required.")
            .NotNull()
            .WithMessage("User Email is required");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .NotNull()
            .WithMessage("Code is required");

        RuleFor(x => x.NewPassword)
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

        RuleFor(x => x.ConfirmNewPassword)
            .Matches(x => x.NewPassword)
            .WithMessage("Confirm password must match the new password");
    }
}