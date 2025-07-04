﻿namespace HotelSystem.Controllers.V1;

[ApiVersion(1.0)]

public class RoomController(ISender sender) : AppController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
       [GreaterThanZero(ErrorMessage = "id must be grater than 0")] int id)
    {
        var response = await sender.Send(new GetRoomById(id));

        return NewResponse(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var response = await sender.Send(new GetAllRooms());

        return NewResponse(response);
    }

    [HttpGet("Offers")]
    public async Task<IActionResult> GetOffers()
    {
        var response = await sender.Send(new GetRoomsWithOffer());

        return NewResponse(response);
    }

    [HttpGet("HotelOffers/{id}")]

    public async Task<IActionResult> GetOffersByHotelId(
               [GreaterThanZero(ErrorMessage = "id must be grater than 0")] int id)
    {
        var response = await sender.Send(new GetHotelOffers(id));

        return NewResponse(response);
    }

    [HttpGet("ByHotelId")]
    public async Task<IActionResult> GetByHotelId(
               [GreaterThanZero(ErrorMessage = "HotelId must be greater than 0")] int hotelId)
    {
        var result = await sender.Send(new GetRoomsByHotelId(hotelId));

        return NewResponse(result);
    }

    [HttpGet("Available")]
    public async Task<IActionResult> GetAvailableRooms()
    {
        var result = await sender.Send(new GetAvilableRooms());

        return NewResponse(result);
    }

    [HttpGet("AvailableWithinHotel/{id}")]

    public async Task<IActionResult> GetAvailableRoomsWithinAHotel(
                      [GreaterThanZero] int id)
    {
        var result = await sender.Send(new GetAvilableRoomsWithinHotel(id));

        return NewResponse(result);
    }

    [HttpGet("ByAreaRange")]
    public async Task<IActionResult> GetByArea(
                      [DecimalGreaterThanZero] decimal minArea,
                      [DecimalGreaterThanZero] decimal maxArea)
    {
        var result = await sender.Send(new GetRoomsByArea(minArea, maxArea));

        return NewResponse(result);
    }

    [HttpGet("ByMaxArea")]
    public async Task<IActionResult> GetByMaxArea(
               [DecimalGreaterThanZero(ErrorMessage = "MaxArea must be greater than 0")] decimal maxArea)
    {
        var result = await sender.Send(new GetRoomsWithMaxArea(maxArea));

        return NewResponse(result);
    }

    [HttpGet("ByMinArea")]
    public async Task<IActionResult> GetByMinArea(
                      [DecimalGreaterThanZero(ErrorMessage = "MinArea must be greater than 0")] decimal minArea)
    {
        var result = await sender.Send(new GetRoomsWithMinArea(minArea));

        return NewResponse(result);
    }

    [HttpGet("ByPriceRange")]
    public async Task<IActionResult> GetByPriceRange(
                      [DecimalGreaterThanZero(ErrorMessage = "MinPrice must be greater than 0")] decimal minPrice,
                                    [DecimalGreaterThanZero(ErrorMessage = "MaxPrice must be greater than 0")] decimal maxPrice)
    {
        var result = await sender.Send(new GetRoomsByPrice(minPrice, maxPrice));

        return NewResponse(result);
    }

    [HttpGet("ByMaxPrice")]
    public async Task<IActionResult> GetByMaxPrice(
                      [DecimalGreaterThanZero(ErrorMessage = "MaxPrice must be greater than 0")] decimal maxPrice)
    {
        var result = await sender.Send(new GetRoomsWithMaxPrice(maxPrice));

        return NewResponse(result);
    }

    [HttpGet("ByMinPrice")]
    public async Task<IActionResult> GetByMinPrice(
                             [DecimalGreaterThanZero(ErrorMessage = "MinPrice must be greater than 0")] decimal minPrice)
    {
        var result = await sender.Send(new GetRoomsWithMinPrice(minPrice));

        return NewResponse(result);
    }

    [HttpGet("ByStatus")]
    public async Task<IActionResult> GetByStatus(
                     [Required] RoomStatus status)
    {
        var result = await sender.Send(new GetRoomsByStatus(status));

        return NewResponse(result);
    }

    [HttpGet("ByType")]
    public async Task<IActionResult> GetByType(
                     [Required] RoomType type)
    {
        var result = await sender.Send(new GetRoomsByType(type));

        return NewResponse(result);
    }






}
