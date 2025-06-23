namespace Core.Features.Hotels.Queries;

public sealed record GetRoomsInAHotel(int HotelId) : IRequest<Response<List<GetRoom>>>
{

}

