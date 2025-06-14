using Core.Mediator.MediatorPipelines.Commands;

namespace Core.Features.Facilities.Commands;

public sealed record CreateFacility(string name) :
    ICommand, IValidatorRequest, IRequest<Response<Facilitiy>>
{
    public string CachedId => "Core-Facilties";
}
