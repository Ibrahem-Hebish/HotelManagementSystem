using Core.Features.Facilities.Commands;

namespace Core.Features.Facilities.Handlers.Commands;

public class CreateFacilityHandler(IRepository<Facilitiy> repository,
    IUnitOfWork unitOfWork)
    : ResponseHandler, IRequestHandler<CreateFacility, Response<Facilitiy>>
{
    public async Task<Response<Facilitiy>> Handle(CreateFacility request, CancellationToken cancellationToken)
    {
        var facility = new Facilitiy()
        {
            Name = request.name
        };

        bool isCreated = await repository.CreateAsync(facility, cancellationToken);

        if (!isCreated)
            return InternalServerError<Facilitiy>();

        else
            await unitOfWork.SaveChangesAsync();

        return Created<Facilitiy>();
    }
}
