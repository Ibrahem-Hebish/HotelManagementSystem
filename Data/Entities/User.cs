namespace Data.Entities;

public class User : IdentityUser, ISoftDeletable
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public UserGender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string? Code { get; set; } // Used for email confirmation or password reset
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<UserToken> UserTokens { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];
    public List<HotelEvaluations> HotelEvaluations { get; set; } = [];
    public List<Hotel> Hotels { get; set; } = []; // Hotels where the user made evaluations

}




