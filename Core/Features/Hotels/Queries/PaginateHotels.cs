using Core.Features.Hotels.Dto;

namespace Core.Features.Hotels.Queries;

public sealed record PaginateHotels(int PageSize, int LastId) : IRequest<CursorPaginatedResponse<List<GetHotel>>>, IValidatorRequest, ICachedQuery
{

    public string CachedId => $"Core-Hotel-Paginate-Cursor-{LastId}-{PageSize}";

    public TimeSpan? Expiration => TimeSpan.FromMinutes(2);
}
