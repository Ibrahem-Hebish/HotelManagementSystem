namespace Core.GenericRespons;

public interface IResponse
{
    string? Message { get; set; }
    HttpStatusCode StatusCode { get; set; }
    bool IsSuccess { get; set; }
}

