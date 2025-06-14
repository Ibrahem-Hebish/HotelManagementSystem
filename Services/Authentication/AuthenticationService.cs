namespace Services.Authentication;

public class AuthenticationService(
    UserManager<User> userManager,
    IOptions<JwtOptions> jwtOptions,
    IConfiguration configuration,
    IRepository<UserToken> userTokenRepository)

    : IAuthenticationService
{
    public async Task<UserToken> CreateToken(User user,
        DateTime refreshTokenExpiredDate,
        string? refreshToken = null)
    {
        string accessToken;

        try
        {
            accessToken = await CreateAccessToken(user);
        }
        catch
        {
            throw new InvalidOperationException("Signing key is missing from configuration.");
        }

        UserToken userToken = new()
        {
            AccessToken = accessToken,
            AccessTokenExpiredDate = DateTime.UtcNow.AddMinutes(jwtOptions.Value.LifeTime),
            RefreshToken = refreshToken is null ? Guid.NewGuid().ToString() : refreshToken,
            RefreshTokenExpiredDate = refreshTokenExpiredDate,
            AddedDate = DateTime.UtcNow,
            Userid = user.Id,
            IsUsed = true,
            IsExpired = false
        };

        await userTokenRepository.CreateAsync(userToken, CancellationToken.None);

        return userToken;
    }
    public async Task<TokenValidationResult> ValidateAccessToken(string accessToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenValidationResult = await tokenHandler.ValidateTokenAsync(
            accessToken, GenerateTokenValidationParameter());

        return tokenValidationResult;
    }
    private async Task<string> CreateAccessToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var signingkey = configuration["jwtsigningkey"];

        if (string.IsNullOrWhiteSpace(signingkey))
            throw new InvalidOperationException("Signing key is missing from configuration.");


        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = jwtOptions.Value.Issuer,

            Audience = jwtOptions.Value.Audience,

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        signingkey!)),
                SecurityAlgorithms.HmacSha256),

            Subject = await GetClaims(user),

            Expires = DateTime.UtcNow.AddMinutes(jwtOptions.Value.LifeTime)

        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        var accessToken = tokenHandler.WriteToken(securityToken);

        return accessToken;
    }
    private async Task<ClaimsIdentity> GetClaims(User user)
    {

        var userClaims = await userManager.GetClaimsAsync(user);
        var userRoles = await userManager.GetRolesAsync(user);

        foreach (var role in userRoles)
            userClaims.Add(new Claim(ClaimTypes.Role, role));

        userClaims.Add(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber!));
        userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id!));
        userClaims.Add(new Claim(ClaimTypes.Name, user.UserName!));
        userClaims.Add(new Claim(ClaimTypes.Email, user.Email!));
        userClaims.Add(new Claim(ClaimTypes.Country, user.Country!));
        userClaims.Add(new Claim(ClaimTypes.DateOfBirth, user.BirthDate!.ToShortDateString()));

        var claimsIdentity = new ClaimsIdentity(userClaims);

        return claimsIdentity;
    }
    private TokenValidationParameters GenerateTokenValidationParameter()
    {
        JwtOptions jwt = new()
        {
            Audience = jwtOptions.Value.Audience,
            Issuer = jwtOptions.Value.Issuer,
            LifeTime = jwtOptions.Value.LifeTime,
        };

        string signingKey = configuration["jwtsigningkey"]!;

        var tokenValidationParameters = TokenValidationParameter
                                          .Generate(jwt, signingKey);

        return tokenValidationParameters;
    }

}

