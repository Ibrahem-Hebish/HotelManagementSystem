using Core.Features.Admin.Commands;
using Core.Features.Admin.Queries;

namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
[Authorize(Roles = "Admin")]
public class AdminController(ISender sender) : AppController
{

    [HttpGet("GetUserById/{id}")]
    public async Task<IActionResult> GetById([Required] string id)
    {
        var response = await sender.Send(new GetUserById(id));

        return NewResponse(response);
    }

    [HttpGet("GetUsers")]
    public async Task<IActionResult> Get()
    {
        var response = await sender.Send(new GetUsers());

        return NewResponse(response);
    }

    [HttpGet("GetByCity/{city}")]
    public async Task<IActionResult> GetByCity(string city)
    {
        var response = await sender.Send(new GetUsersByCity(city));

        return NewResponse(response);
    }

    [HttpGet("GetByCountry/{country}")]
    public async Task<IActionResult> GetByCountry(string country)
    {
        var response = await sender.Send(new GetUsersByCountry(country));

        return NewResponse(response);
    }

    [HttpPost("GetByEmail")]
    public async Task<IActionResult> GetByEmail(GetUsers command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("GetByUsername")]
    public async Task<IActionResult> GetByUserName(GetUserByUsername command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("GetByPhoneNumber")]
    public async Task<IActionResult> GetByPhoneNumber(GetUserByPhone command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("AddAdmin")]
    public async Task<IActionResult> CreateAdmin(CreateAdmin command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("AddVendor")]
    public async Task<IActionResult> CreateVendor(CreateVendor command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }
    [HttpDelete("DeleteUser/{id}")]
    public async Task<IActionResult> DeleteUser([Required] string id)
    {
        var response = await sender.Send(new DeleteUser(id));

        return NewResponse(response);
    }


}
