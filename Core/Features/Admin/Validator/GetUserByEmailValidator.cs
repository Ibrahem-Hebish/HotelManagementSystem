using Core.Features.Admin.Queries;

namespace Core.Features.Admin.Validator;

public class GetUserByEmailValidator : AbstractValidator<GetUserByEmail>
{

    public GetUserByEmailValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .NotEmpty()
            .WithMessage("Email is required.");
    }
}
