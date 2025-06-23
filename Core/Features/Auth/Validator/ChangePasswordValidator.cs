using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

public class ChangePasswordValidator : AbstractValidator<ChangePassword>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.")
            .NotNull()
            .WithMessage("User ID is required.");

        RuleFor(x => x.OldPassword)
            .NotEmpty()
            .WithMessage("Old password is required.")
            .NotNull()
            .WithMessage("Old password is required");

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
