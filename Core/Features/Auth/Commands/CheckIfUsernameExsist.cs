namespace Core.Features.Auth.Commands;

public sealed record CheckIfUsernameExsist(string Username) : IRequest<Response<bool>>, IValidatorRequest { }


