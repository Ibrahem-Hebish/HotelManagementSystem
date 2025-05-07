namespace Data.Entities;

public class Hotel : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public List<Room> Rooms { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];

}


