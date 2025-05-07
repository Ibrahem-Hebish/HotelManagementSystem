namespace Core.Mediator.MediatorNotification;

public record UserCreatedNotification(User User) : INotification
{
}


