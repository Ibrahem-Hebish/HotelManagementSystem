using Core.Features.Facilities.Commands;

namespace Core.Features.Facilities.Validators;

public class CreateFacilityValidator : AbstractValidator<CreateFacility>
{
    public CreateFacilityValidator()
    {
        RuleFor(x => x.name)
            .NotEmpty().WithMessage("Name can not be empty")
            .NotNull().WithMessage("Name can not be null")
            .MinimumLength(3).WithMessage("Name must be greater than 2 characters");
    }
}
