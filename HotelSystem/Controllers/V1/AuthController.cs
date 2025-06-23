using Core.Features.Auth.Commands;
using Core.Features.Customers.Commands;

namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]

public class AuthController(ISender sender) : AppController
{
    [HttpPost("CheckEmailExists")]
    public async Task<IActionResult> CheckEmailExists(CheckIfEmailExsist command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("CheckUserNameExists")]
    public async Task<IActionResult> CheckUserNameExists(CheckIfUsernameExsist command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(CreateUser command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmail command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost]
    [Route("SignIn")]
    [EnableRateLimiting(policyName: "SignInLimit")]
    public async Task<IActionResult> SignIn(SignIn command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost]
    [Route("SignOut")]
    [Authorize]
    public async Task<IActionResult> SignOut([Required] string id, [GreaterThanZero] int tokenId)
    {

        var response = await sender.Send(new SignOut(id, tokenId));

        return NewResponse(response);
    }

    [HttpPost]
    [Route("RefrehToken")]
    public async Task<IActionResult> RefrehToken([GreaterThanZero] int id)
    {

        var response = await sender.Send(new RefreshToken(id));

        return NewResponse(response);
    }

    [HttpPost]
    [Route("SendCodeToReseatPassword")]
    public async Task<IActionResult> SendCodeToReseatPassword(SendCodeToReseatPassword command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost]
    [Route("ReseatPassword")]
    public async Task<IActionResult> ReseatPassword(ReseatPassword command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }

    [HttpPost]
    [Route("ChangePassword")]
    [Authorize]
    public async Task<IActionResult> ChangePassword(ChangePassword command)
    {
        var response = await sender.Send(command);

        return NewResponse(response);
    }
}
