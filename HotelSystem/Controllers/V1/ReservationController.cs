using Core.Features.Reservations.Commands;
using Core.Features.Reservations.Dtos;
using Core.Features.Reservations.Queries;

namespace HotelSystem.Controllers.V1;

[ApiVersion("1.0")]
public class ReservationController(ISender sender) : AppController
{
    [HttpGet("{id}")]
    [Authorize(policy: "AccessReservationById")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await sender.Send(new GetReservationById(id));

        return NewResponse(result);
    }

    [HttpGet("GetHotelReservations/{id}")]
    [Authorize(policy: "AccessHotelReservations")]
    public async Task<IActionResult> GetHotelReservations([GreaterThanZero] int id)
    {
        var result = await sender.Send(new GetHotelReservations(id));

        return NewResponse(result);
    }

    [HttpGet("GetCustomerReservations/{id}")]
    [Authorize(policy: "AccessCustomerReservations")]
    public async Task<IActionResult> GetCustomerReservations(string id)
    {
        var result = await sender.Send(new GetCustomerReservations(id));

        return NewResponse(result);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateReservation(AddReservation command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }
    [HttpPatch("{id}")]
    [Authorize(policy: "ModifyReservation")]
    public async Task<IActionResult> UpdateReservation(int id, PatchReservationDto dto)
    {
        var command = new PatchReservation(id, dto.CheckOutDate, dto.FoodServiceType, dto.ReservationStatus, dto.PaymentStatus);

        var result = await sender.Send(command);

        return NewResponse(result);
    }
}
