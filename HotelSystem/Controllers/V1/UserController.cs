using Core.Features.Users.Commands;
using Core.Features.Users.Queries;

namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiversion}/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(
               [Required] string id)
    {
        var response = await sender.Send(new GetUserById(id));

        return Ok(response);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get()
    {
        var response = await sender.Send(new GetUsers());

        return Ok(response);
    }

    [HttpGet("Evaluations/{id}")]
    [Authorize(policy: "AccessUserEvaluation")]
    public async Task<IActionResult> GetEvaluations(string id)
    {
        var result = await sender.Send(new GetUserEvaluationsToHotels(id));

        return Ok(result);
    }

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] PatchUser command)
    {

        var response = await sender.Send(command);

        return Ok(response);
    }


    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(
               [FromBody] CreateUser command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("AddAdmin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAdmin(
               [FromBody] CreateAdmin command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("AddVendor")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateVendor(
               [FromBody] CreateVendor command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("SignIn")]
    [EnableRateLimiting(policyName: "SignInLimit")]
    public async Task<IActionResult> SignIn(
               [FromBody] SignIn command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("SignOut")]
    [Authorize]
    public async Task<IActionResult> SignOut(
               [Required] string id, [GreaterThanZero] int tokenId)
    {

        var response = await sender.Send(new SignOut(id, tokenId));

        return Ok(response);
    }

    [HttpPost]
    [Route("RefrehToken")]
    public async Task<IActionResult> RefrehToken(
               [GreaterThanZero] int id)
    {

        var response = await sender.Send(new RefreshToken(id));

        return Ok(response);
    }

    [HttpPost]
    [Route("SendCodeToReseatPassword")]
    public async Task<IActionResult> SendCodeToReseatPassword(
                      [FromBody] SendCodeToReseatPassword command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("ReseatPassword")]
    public async Task<IActionResult> ReseatPassword(
                      [FromBody] ReseatPassword command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }

    [HttpPost]
    [Route("ChangePassword")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(
                             [FromBody] ChangePassword command)
    {
        var response = await sender.Send(command);

        return Ok(response);
    }
}
