using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Validator;

public class SignOutValidator : AbstractValidator<SignOut>
{
    public SignOutValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("User ID is required.")
            .NotNull()
            .WithMessage("User ID is required");

        RuleFor(x => x.TokenId)
            .GreaterThan(0)
            .WithMessage("Token ID must be greater than zero.");
    }
}
