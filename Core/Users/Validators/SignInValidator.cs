namespace Core.Users.Validators;

public class SignInValidator : AbstractValidator<SignIn>
{
    public SignInValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .NotNull()
            .WithMessage("Password is required");
    }
}
