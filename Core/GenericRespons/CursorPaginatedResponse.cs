namespace Core.GenericRespons;

public class CursorPaginatedResponse<T> : IResponse
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public bool HasNextPage => Data is ICollection<T> collection && collection.Count == PageSize;
    public int LastId { get; set; }

    public CursorPaginatedResponse(T? data, int totalCount, int pageSize, int lastId)
    {
        Data = data;
        TotalCount = totalCount;
        PageSize = pageSize;
        LastId = lastId;
        IsSuccess = true;
        StatusCode = TotalCount > 0 ? HttpStatusCode.OK : HttpStatusCode.NoContent;
    }
}