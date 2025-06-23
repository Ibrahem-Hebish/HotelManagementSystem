using Core.Features.Admin.Queries;

namespace Core.Features.Admin.Validator;

public class GetUsersByCountryValidator : AbstractValidator<GetUsersByCountry>
{
    public GetUsersByCountryValidator()
    {
        RuleFor(x => x.Country)
            .NotEmpty()
            .WithMessage("Country is required.")
            .NotNull()
            .WithMessage("Country can not be null.");
    }
}
