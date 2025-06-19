using Core.Features.Users.Commands;
using Core.Features.Users.Queries;

namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
public class UserController(ISender sender) : AppController
{

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById([Required] string id)
    {
        var response = await sender.Send(new GetUserById(id));

        return NewRespnse(response);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get()
    {
        var response = await sender.Send(new GetUsers());

        return NewRespnse(response);
    }

    [HttpGet("Evaluations/{id}")]
    [Authorize(policy: "AccessUserEvaluation")]
    public async Task<IActionResult> GetEvaluations(string id)
    {
        var result = await sender.Send(new GetUserEvaluationsToHotels(id));

        return NewRespnse(result);
    }
    [HttpPost("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmail command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost("CheckEmailExists")]
    public async Task<IActionResult> CheckEmailExists(CheckIfEmailExsist command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost("CheckUserNameExists")]
    public async Task<IActionResult> CheckUserNameExists(CheckIfUsernameExsist command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] PatchUser command)
    {

        var response = await sender.Send(command);

        return NewRespnse(response);
    }


    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(CreateUser command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("AddAdmin")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAdmin(CreateAdmin command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("AddVendor")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateVendor(CreateVendor command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("SignIn")]
    [EnableRateLimiting(policyName: "SignInLimit")]
    public async Task<IActionResult> SignIn(SignIn command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("SignOut")]
    [Authorize]
    public async Task<IActionResult> SignOut([Required] string id, [GreaterThanZero] int tNewRespnseenId)
    {

        var response = await sender.Send(new SignOut(id, tNewRespnseenId));

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("RefrehToken")]
    public async Task<IActionResult> RefrehToken([GreaterThanZero] int id)
    {

        var response = await sender.Send(new RefreshToken(id));

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("SendCodeToReseatPassword")]
    public async Task<IActionResult> SendCodeToReseatPassword(SendCodeToReseatPassword command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("ReseatPassword")]
    public async Task<IActionResult> ReseatPassword(ReseatPassword command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }

    [HttpPost]
    [Route("ChangePassword")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePassword command)
    {
        var response = await sender.Send(command);

        return NewRespnse(response);
    }
}
