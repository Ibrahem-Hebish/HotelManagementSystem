using Services.Enums;
using Services.GenericRepository;


namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiversion}/[controller]")]
[ApiController]
public class RoomController(IRepository<Room> repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await repository.GetAsync(Tracking.AsNoTracking);

        return Ok(response.ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(
        [GreaterThanZero(ErrorMessage = "id must be grater than 0")] int id)
    {
        var response = await repository.GetByIdAsync(id, Tracking.AsNoTracking, CancellationToken.None);

        return Ok(response);
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
