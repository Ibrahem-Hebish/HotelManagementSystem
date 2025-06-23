using Core.Features.Admin.Queries;
using Core.Features.Customers.Commands;
using Core.Features.Customers.Queries;
using System.Security.Claims;

namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]
public class CustomerController(ISender sender) : AppController
{
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMe()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var response = await sender.Send(new GetUserById(userId));

        return NewResponse(response);
    }

    [HttpGet("Reviews/{id}")]
    [Authorize(policy: "AccessUserReviews")]
    public async Task<IActionResult> GetReviews(string id)
    {
        var result = await sender.Send(new GetCustomerReviews(id));

        return NewResponse(result);
    }

    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] PatchUser command)
    {

        var response = await sender.Send(command);

        return NewResponse(response);
    }

}