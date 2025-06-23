namespace Core.Features.Auth.Commands;

public sealed record RefreshToken(int id) : IRequest<Response<UserToken>> { }