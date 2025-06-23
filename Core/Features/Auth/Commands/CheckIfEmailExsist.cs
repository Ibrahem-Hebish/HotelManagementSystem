namespace Core.Features.Auth.Commands;

public sealed record CheckIfEmailExsist(string Email) : IRequest<Response<bool>>, IValidatorRequest { }


