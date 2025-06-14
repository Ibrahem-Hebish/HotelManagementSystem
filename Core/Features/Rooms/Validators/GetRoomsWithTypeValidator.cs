using Core.Features.Rooms.Queries;

namespace Core.Features.Rooms.Validators;

public class GetRoomsWithTypeValidator : AbstractValidator<GetRoomsByType>
{

    public GetRoomsWithTypeValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage("Room type must not be empty.")
            .NotNull()
            .WithMessage("Room type can not be null");
    }
}
