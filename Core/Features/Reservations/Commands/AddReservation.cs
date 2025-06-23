namespace Core.Features.Reservations.Commands;

public class AddReservation : IRequest<Response<bool>>, IValidatorRequest
{
    public int HotelId { get; set; }
    public int RoomId { get; set; }
    public string CustomerId { get; set; } = "";
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public FoodServiceType FoodServiceType { get; set; }
    public ReservationStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

}


