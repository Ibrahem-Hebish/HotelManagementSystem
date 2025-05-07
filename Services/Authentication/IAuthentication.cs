namespace Services.Authentication;

public interface IAuthenticationService
{
    public Task<UserToken> CreateToken(User user, DateTime refreshTokenExpiredDate, string? refreshToken = null);
    public Task<TokenValidationResult> ValidateAccessToken(string accessToken);
}

