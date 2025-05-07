namespace Services.Authentication;

public class TokenValidationParameter
{

    public static TokenValidationParameters Generate(JwtOptions jwtOptions, string signingkey)
    {
        ArgumentNullException.ThrowIfNull(jwtOptions);
        ArgumentException.ThrowIfNullOrWhiteSpace(signingkey);

        var tokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtOptions.Audience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(signingkey)),
        };

        return tokenValidationParameters;
    }

}

