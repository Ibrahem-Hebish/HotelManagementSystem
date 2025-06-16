namespace Services.Repositories.Interfaces;

public interface IUserTokenRepository
{
    Task<UserToken> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<UserToken>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
    Task<List<UserToken>> GetUserTokens(string userId, Tracking tracking, CancellationToken cancellationToken);
    Task<UserToken> GetUserToken(string userId, int tokenId, Tracking tracking, CancellationToken cancellationToken);
}
