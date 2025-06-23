using Core.Features.Admin.Queries;

namespace Core.Features.Admin.Validator;

public class GetUserByUsernameValidator : AbstractValidator<GetUserByUsername>
{
    public GetUserByUsernameValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required.");
    }
}
