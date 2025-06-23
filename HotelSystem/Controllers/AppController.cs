using Core.GenericRespons;
using System.Net;

namespace HotelSystem.Controllers;

[Route("api/v{version:apiversion}/[controller]")]
[ApiController]
public class AppController : ControllerBase
{
    protected IActionResult NewResponse<T>(T response) where T : IResponse
    {
        return response.StatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.NoContent => StatusCode((int)HttpStatusCode.NoContent, response),
            HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
            HttpStatusCode.Created => CreatedAtAction(nameof(Response), response),
            HttpStatusCode.BadRequest => BadRequest(response),
            HttpStatusCode.Unauthorized => Unauthorized(response),
            HttpStatusCode.NotFound => NotFound(response),
            _ => StatusCode((int)response.StatusCode, response),
        };
    }
}
