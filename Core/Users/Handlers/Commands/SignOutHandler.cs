namespace Core.Users.Handlers.Commands;

public class SignOutHandler(IRepository<UserToken> repository,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<SignOut, Response<string>>
{
    public async Task<Response<string>> Handle(SignOut request, CancellationToken cancellationToken)
    {
        Log.Information("Signing out user with id: {@UserId}", request.userId);

        var userTokens = await repository
            .GetAsync(Tracking.AsTracking);

        var userToken = userTokens.OrderBy(x => x.Id)
            .LastOrDefault(x => x.Userid == request.userId);

        if (userToken is not null)
        {
            userToken.IsExpired = true;
            userToken.IsUsed = false;
            userToken.RefreshTokenExpiredDate = DateTime.UtcNow;
            userToken.AccessTokenExpiredDate = DateTime.UtcNow;

            await repository.UpdateAsync(userToken, userToken.Id);

            await unitOfWork.SaveChangesAsync();
        }
        Log.Information("User with id: {@UserId} signed out successfully", request.userId);

        return Success("User signed out successfully");

    }
}
