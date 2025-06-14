using Core.Features.Hotels.Queries;

namespace Core.Features.Hotels.Validators;

public class PaginateHotelsValidator : AbstractValidator<PaginateHotels>
{
    public PaginateHotelsValidator()
    {
        RuleFor(x => x.LastId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Page number must be greater than 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("Page size must be greater than 0");
    }
}



