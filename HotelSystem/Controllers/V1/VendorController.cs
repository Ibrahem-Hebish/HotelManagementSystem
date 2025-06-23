using Core.Features.Admin.Queries;
using Core.Features.Vendor.Queries;

namespace HotelSystem.Controllers.V1;

[ApiVersion("1.0")]
public class VendorController(ISender sender) : AppController
{
    [HttpGet("GetCustomerById/{id}")]
    [Authorize(Policy = "AccessCustomerDataPermission")]
    public async Task<IActionResult> GetCustomerById([FromRoute] string id)
    {
        var response = await sender.Send(new GetUserById(id));

        return NewResponse(response);
    }

    [HttpGet("GetCustomers/{vendorId}")]
    [Authorize(Roles = "Admin,Vendor")]
    public async Task<IActionResult> GetCustomers([FromRoute] string vendorId)
    {
        var response = await sender.Send(new GetCustomers(vendorId));

        return NewResponse(response);
    }
}
