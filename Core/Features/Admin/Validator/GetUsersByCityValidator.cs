using Core.Features.Admin.Queries;

namespace Core.Features.Admin.Validator;

public class GetUsersByCityValidator : AbstractValidator<GetUsersByCity>
{
    public GetUsersByCityValidator()
    {
        RuleFor(x => x.City)
            .NotEmpty()
            .WithMessage("City is required.")
            .NotNull()
            .WithMessage("City can not be null.");
    }
}