using Core.Features.Admin.Queries;

namespace Core.Features.Admin.Validator;

public class GetUserByPhoneValidator : AbstractValidator<GetUserByPhone>
{

    public GetUserByPhoneValidator()
    {
        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .WithMessage("Invalid phone number format.");
    }
}
