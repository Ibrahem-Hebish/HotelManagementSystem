namespace Data.Entities;

public class Reservation : IEntity
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public FoodServiceType FoodServiceType { get; set; }
    public ReservationStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal TotalPrice { get; set; }
    public byte[] Rowversion { get; set; }
    public int RoomId { get; set; }
    [ForeignKey(nameof(RoomId))]
    public Room Room { get; set; }
    public string CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
    public int HotelId { get; set; }
    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; }
}


