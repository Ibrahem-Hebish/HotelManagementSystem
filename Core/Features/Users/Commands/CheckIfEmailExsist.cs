namespace Core.Features.Users.Commands;

public sealed record CheckIfEmailExsist(string Email) : IRequest<Response<bool>>, IValidatorRequest { }


