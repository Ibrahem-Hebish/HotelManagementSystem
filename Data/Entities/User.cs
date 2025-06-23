namespace Data.Entities;

public class User : IdentityUser, ISoftDeletable
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public UserGender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<UserToken> UserTokens { get; set; } = [];
    // Hotels where the user made evaluations
}

public class Vendor : User
{
    public List<Hotel> Hotels { get; set; } = []; // Hotels owned by the vendor
}

public class Customer : User
{
    public List<Reservation> Reservations { get; set; } = [];
    public List<HotelReviews> HotelReviews { get; set; } = [];
    public List<HotelCustomer> HotelCustomers { get; set; } = [];
    public List<Hotel> Hotels { get; set; } = [];
}


