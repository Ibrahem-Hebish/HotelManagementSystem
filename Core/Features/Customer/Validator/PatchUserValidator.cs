using Core.Features.Customers.Commands;

namespace Core.Features.Customers.Validator;

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