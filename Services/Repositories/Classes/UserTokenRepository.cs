
namespace Services.Repositories.Classes;

public class UserTokenRepository(AppDbContext context) : IUserTokenRepository
{
    private readonly DbSet<UserToken> dbSet = context.UserTokens;

    public async Task<List<UserToken>> GetAsync(Tracking tracking, CancellationToken cancellationToken)
    {
        var userTokens = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
            userTokens = userTokens.AsTracking();

        return await userTokens
            .ToListAsync(cancellationToken);
    }

    public async Task<UserToken?> GetByIdAsync(int id, Tracking tracking, CancellationToken cancellationToken)
    {
        var userToken = dbSet.AsQueryable();

        if (tracking == Tracking.AsTracking)
            userToken = userToken.AsTracking();

        return await userToken
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

}
