﻿namespace Core.Features.Hotels.Queries;

public sealed record GetHotelsByName(string Name) : IRequest<Response<List<GetHotel>>>
{

}

