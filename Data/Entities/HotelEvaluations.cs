namespace Data.Entities;

public class HotelEvaluations
{
    public int HotelId { get; set; }
    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;

    public string UserId { get; set; } = "";
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;

    public int Rate { get; set; }
    public string Comment { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
