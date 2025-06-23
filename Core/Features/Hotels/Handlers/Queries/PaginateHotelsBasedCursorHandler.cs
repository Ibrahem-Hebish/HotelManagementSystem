namespace Core.Features.Hotels.Handlers.Queries;

public class PaginateHotelsHandler(
    IHotelRepository hotelRepository,
    IMapper mapper)

    : ResponseHandler,
      IRequestHandler<PaginateHotels, CursorPaginatedResponse<List<GetHotel>>>
{
    public async Task<CursorPaginatedResponse<List<GetHotel>>> Handle(PaginateHotels request, CancellationToken cancellationToken)
    {

        var (hotels, count) = await hotelRepository.Paginate(request.PageSize, request.LastId,
                                                                 Tracking.AsNoTracking, cancellationToken);

        if (hotels.Count == 0)
            return new CursorPaginatedResponse<List<GetHotel>>([], 0, request.PageSize, 0)
            {
                Message = "No hotels found",
                StatusCode = HttpStatusCode.NotFound,
                IsSuccess = true,
            };

        var result = mapper.Map<List<GetHotel>>(hotels);

        var lastId = hotels.LastOrDefault()!.Id;

        return new CursorPaginatedResponse<List<GetHotel>>(result, count, request.PageSize, lastId)
        {
            Message = "Hotels retrieved successfully",
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true,
        };

    }
}