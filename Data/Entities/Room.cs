namespace Data.Entities;

public class Room
{
    public int Id { get; set; }
    public RoomType Type { get; set; }
    public RoomStatus Status { get; set; }
    public decimal Area { get; set; }
    public string? Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int? DiscountPercentage { get; set; }
    public int HotelId { get; set; }
    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; }
    public List<Facilitiy> Facilitiy { get; set; } = [];
    public List<RoomFacilities> RoomFacilities { get; set; } = [];
    public List<Photo> Photos { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];


}
