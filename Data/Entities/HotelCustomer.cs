namespace Data.Entities;

public class HotelCustomer
{
    public string CustomerId { get; set; } = "";
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;
    public int HotelId { get; set; }
    [ForeignKey(nameof(HotelId))]
    public Hotel Hotel { get; set; } = null!;
}


