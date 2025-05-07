namespace Core.Users.Commands;

public sealed record RefreshToken(int id) : IRequest<Response<UserToken>> { }