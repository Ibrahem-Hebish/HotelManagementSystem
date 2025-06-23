namespace Core.Features.Reservations.Dtos;

public class PatchReservationDto
{
    public DateTime? CheckOutDate { get; set; }
    public FoodServiceType? FoodServiceType { get; set; }
    public ReservationStatus? ReservationStatus { get; set; }
    public PaymentStatus? PaymentStatus { get; set; }
}