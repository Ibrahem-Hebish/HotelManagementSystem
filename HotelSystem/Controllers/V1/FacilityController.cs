namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiversion}/[controller]")]
[ApiController]
public class FacilityController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await mediator.Send(new GetFacilties());

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(
        [GreaterThanZero(ErrorMessage = "Id must be greater than zero.")] int id)
    {
        var response = await mediator.Send(new GetFacilityById(id));

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateFacility command)
    {
        var response = await mediator.Send(command);

        return Ok(response);
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
