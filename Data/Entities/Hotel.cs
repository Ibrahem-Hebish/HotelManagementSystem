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
    public List<HotelReviews> HotelReviews { get; set; } = [];
    public List<Customer> Customers { get; set; } = []; // Users who have made reservations at the hotel
    public string OwnerId { get; set; } = "";
    public Vendor Owner { get; set; } = null!; // The owner of the hotel, represented by a User entity
    public List<HotelCustomer> HotelCustomers { get; set; } = []; // Customers who have made reservations at the hotel

}


