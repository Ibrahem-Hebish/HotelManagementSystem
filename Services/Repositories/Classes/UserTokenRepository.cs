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

    public async Task<UserToken> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var userToken = await dbSet.FindAsync(id, cancellationToken);

        return userToken!;
    }

    public async Task<List<UserToken>> GetUserTokens(string userId, Tracking tracking, CancellationToken cancellationToken)
    {
        var userTokens = dbSet
                             .Where(x => x.Userid == userId);

        if (tracking == Tracking.AsTracking)
            userTokens = userTokens.AsTracking();

        return await userTokens
            .ToListAsync(cancellationToken);
    }

    public async Task<UserToken> GetUserToken(string userId, int tokenId, Tracking tracking, CancellationToken cancellationToken)
    {
        var tokens = dbSet
            .Where(x => x.Userid == userId && x.Id == tokenId);

        if (tracking == Tracking.AsTracking)
            tokens = tokens.AsTracking();

        var token = await tokens.FirstOrDefaultAsync(cancellationToken);

        return token!;
    }

}
