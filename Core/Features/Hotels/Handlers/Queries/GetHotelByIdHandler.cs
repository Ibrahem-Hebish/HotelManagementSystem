using Core.Features.Hotels.Dto;
using Core.Features.Hotels.Queries;

namespace Core.Features.Hotels.Handlers.Queries;

internal class GetHotelByIdHandler(
    IHotelRepository repository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetHotelById, Response<GetHotel>>
{
    public async Task<Response<GetHotel>> Handle(GetHotelById request, CancellationToken cancellationToken)
    {
        var hotel = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (hotel is null)
            return NotFouned<GetHotel>();

        var hotelDto = mapper.Map<GetHotel>(hotel);

        return Success(hotelDto);
    }
}
