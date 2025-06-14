namespace Services.Repositories.Interfaces;

public interface IUserTokenRepository
{
    Task<UserToken> GetByIdAsync(int id, Tracking tracking,
               CancellationToken cancellationToken);
    Task<List<UserToken?>> GetAsync(Tracking tracking, CancellationToken cancellationToken);
}
