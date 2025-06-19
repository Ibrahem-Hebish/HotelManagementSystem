namespace Core.Features.Users.Commands;

public sealed record CheckIfUsernameExsist(string Username) : IRequest<Response<bool>>, IValidatorRequest { }


