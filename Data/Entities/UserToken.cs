namespace Data.Entities;

public class UserToken : IEntity
{
    public int Id { get; set; }
    public string AccessToken { get; set; } = "";
    public DateTime AccessTokenExpiredDate { get; set; }
    public string RefreshToken { get; set; } = "";
    public DateTime AddedDate { get; set; }
    public DateTime RefreshTokenExpiredDate { get; set; }
    public bool IsUsed { get; set; }
    public bool IsExpired { get; set; }
    public string Userid { get; set; } = "";
    public virtual User User { get; set; }


}




