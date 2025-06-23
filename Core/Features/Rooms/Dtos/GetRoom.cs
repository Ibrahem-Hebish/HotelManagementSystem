namespace Core.Features.Rooms.Dtos;

public class GetRoom
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public decimal Area { get; set; }
    public string? Description { get; set; }
    public decimal PricePerNight { get; set; }
    public int? DiscountPercentage { get; set; }
    public decimal TotalPrice => DiscountPercentage is null ? PricePerNight : PricePerNight * (1 - DiscountPercentage.Value / 100m);
    public string HotelName { get; set; } = "";
    public List<string> Facilitiy { get; set; } = [];
    public List<string> PhotosPaths { get; set; } = [];
}
