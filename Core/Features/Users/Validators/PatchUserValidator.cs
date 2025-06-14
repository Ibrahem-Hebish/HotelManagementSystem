using Core.Features.Users.Commands;

namespace Core.Features.Users.Validators;

public class PatchUserValidator : AbstractValidator<PatchUser>
{
    public PatchUserValidator()
    {
        RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id can not be empty.")
             .NotNull()
             .WithMessage("Id can not be null.");
    }
}