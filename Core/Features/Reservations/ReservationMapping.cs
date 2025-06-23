using Core.Features.Reservations.Commands;

namespace Core.Features.Reservations;

public static class ReservationMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<AddReservation, Reservation>.NewConfig()
            .Map(dest => dest.CustomerId, src => src.CustomerId.Trim())
            .Map(dest => dest.HotelId, src => src.HotelId)
            .Map(dest => dest.RoomId, src => src.RoomId);
    }
}
