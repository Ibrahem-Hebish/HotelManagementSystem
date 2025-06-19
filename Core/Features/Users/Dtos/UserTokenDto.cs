namespace Core.Features.Users.Dtos;

public class UserTokenDto
{
    public string Userid { get; set; } = "";
    public string AccessToken { get; set; } = "";
    public DateTime AccessTokenExpiredDate { get; set; }
    public string RefreshToken { get; set; } = "";
    public DateTime AddedDate { get; set; }
    public DateTime RefreshTokenExpiredDate { get; set; }
    public bool IsExpired { get; set; }
}