using Core.Features.Auth.Commands;

namespace Core.Features.Auth.Handlers.Commands;

public class SignOutHandler(
    IUserTokenRepository queryRepo,
    IRepository<UserToken> commandRepo,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<SignOut, Response<string>>
{
    public async Task<Response<string>> Handle(SignOut request, CancellationToken cancellationToken)
    {
        Log.Information("Signing out user with id: {@UserId}", request.UserId);

        var userToken = await queryRepo
            .GetUserToken(request.UserId, request.TokenId, Tracking.AsTracking, cancellationToken);

        if (userToken is null)
            return NotFouned<string>("There is no token with this id");

        userToken.IsExpired = true;
        userToken.RefreshTokenExpiredDate = DateTime.UtcNow;
        userToken.AccessTokenExpiredDate = DateTime.UtcNow;

        await commandRepo.UpdateAsync(userToken, userToken.Id);

        await unitOfWork.SaveChangesAsync();

        Log.Information("User with id: {@UserId} signed out successfully", request.UserId);

        return Success("User signed out successfully");

    }
}
