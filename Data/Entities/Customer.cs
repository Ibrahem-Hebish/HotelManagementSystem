namespace Data.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public List<Reservation> Reservations { get; set; } = [];
}


