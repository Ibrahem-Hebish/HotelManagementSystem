using Data.Enums;

namespace Core.Rooms.Dtos;

public class GetRoom
{
    public int Id { get; set; }
    public RoomType Type { get; set; }
    public RoomStatus Status { get; set; }
    public decimal Area { get; set; }
    public string? Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int? DiscountPercentage { get; set; }
    public string HotelName { get; set; } = "";
    public List<string> Facilitiy { get; set; } = [];
    public List<string> PhotosPaths { get; set; } = [];
}
