using Core.Features.Customers.Dtos;

namespace Core.Features.Reservations.Dtos;

public class GetReservation
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public string FoodServiceType { get; set; } = "";
    public string Status { get; set; } = "";
    public string PaymentStatus { get; set; } = "";
    public decimal TotalPrice { get; set; }
    public string HotelName { get; set; } = "";
    public GetRoom Room { get; set; } = null!;
    public GetUser User { get; set; } = null!; // Customer who made the reservation 
}
