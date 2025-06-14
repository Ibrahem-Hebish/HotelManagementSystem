namespace Data.Entities;

public class Hotel : IEntity, ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Country { get; set; } = "";
    public string City { get; set; } = "";
    public string Street { get; set; } = "";
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Room> Rooms { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];
    public List<HotelEvaluations> HotelEvaluations { get; set; } = [];
    public List<User> Customers { get; set; } = []; // Users who have made reservations at the hotel

}


