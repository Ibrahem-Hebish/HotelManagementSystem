using Core.Features.Users.Commands;

namespace Core.Features.Users.Handlers.Commands;

public class RefreshTokenHandler(IAuthenticationService authenticationService,
    IUserTokenRepository queryRepo,
    IRepository<UserToken> commandRepo,
    UserManager<User> userManager,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<RefreshToken, Response<UserToken>>
{
    public async Task<Response<UserToken>> Handle(RefreshToken request, CancellationToken cancellationToken)
    {
        using var transaction = unitOfWork.BeginTransaction();

        Log.Information("Refreshing token with id: {@Id}", request.id);

        try
        {
            var userToken = await queryRepo
                                  .GetByIdAsync(request.id, cancellationToken);
            if (userToken is null)
                return NotFouned<UserToken>("There is no token with this id");

            var user = await userManager.FindByIdAsync(userToken.Userid);

            if (user is null)
                return NotFouned<UserToken>("There is no user attached to this token");

            var accessTokenValidationResult = await authenticationService
                                                      .ValidateAccessToken(userToken.AccessToken);

            if (!accessTokenValidationResult.IsValid)
                return BadRequest<UserToken>("Access token is not valid");

            if (userToken.AccessTokenExpiredDate > DateTime.UtcNow)
                return BadRequest<UserToken>("Access token is not expired yet");

            if (userToken.RefreshTokenExpiredDate < DateTime.UtcNow)
                return BadRequest<UserToken>("Refresh token is expired");

            var newToken = await authenticationService
                                              .CreateToken(user,
                                                  userToken.RefreshTokenExpiredDate,
                                                    userToken.RefreshToken);

            userToken.IsExpired = true;
            userToken.RefreshTokenExpiredDate = DateTime.UtcNow;

            await commandRepo.UpdateAsync(userToken, userToken.Id);

            await unitOfWork.SaveChangesAsync();

            await unitOfWork.CommitTransaction();

            return Success(newToken);
        }

        catch (Exception ex)
        {
            Log.Error(ex, "Error while refreshing token");

            await unitOfWork.RollBack();

            return InternalServerError<UserToken>(ex.Message!);
        }

    }
}
