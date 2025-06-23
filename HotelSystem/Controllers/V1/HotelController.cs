namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
public class HotelController(ISender sender) : AppController
{

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
               [GreaterThanZero(ErrorMessage = "id must be grater than 0")] int id)
    {
        var response = await sender.Send(new GetHotelById(id));

        return NewResponse(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await sender.Send(new GetAllHotels());

        return NewResponse(response);
    }

    [HttpGet("GetByCity/{city}")]
    public async Task<IActionResult> GetByCity(
                      [Required] string city)
    {
        var response = await sender.Send(new GetHotelsByCity(city));

        return NewResponse(response);
    }

    [HttpGet("GetByCountry/{country}")]
    public async Task<IActionResult> GetByCountry(
                             [Required] string country)
    {
        var response = await sender.Send(new GetHotelsByCountry(country));

        return NewResponse(response);
    }

    [HttpGet("Paginate")]

    public async Task<IActionResult> PaginateBasedCursor(
                      [FromQuery] int pageSize = 10,
                              [FromQuery] int lastId = 0)
    {
        var response = await sender.Send(new PaginateHotels(pageSize, lastId));

        return NewResponse(response);
    }

    [HttpPost("Search")]

    public async Task<IActionResult> Search(
                             [FromBody] HotelSearch request)
    {
        var response = await sender.Send(request);

        return NewResponse(response);
    }
}
