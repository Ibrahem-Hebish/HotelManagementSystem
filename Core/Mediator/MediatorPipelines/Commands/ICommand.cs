namespace Core.Mediator.MediatorPipelines.Commands;

public interface ICommand
{
    string CachedId { get; }
}