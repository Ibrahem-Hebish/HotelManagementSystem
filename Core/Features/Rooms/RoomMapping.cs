﻿namespace Core.Features.Rooms;

public static class RoomMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<Room, GetRoom>.NewConfig()
            .Map(dest => dest.Type, src => src.Type.ToString())
            .Map(dest => dest.Status, src => src.Status.ToString())
            .Map(dest => dest.HotelName, src => src.Hotel.Name)
            .Map(dest => dest.Facilitiy, src => src.Facilitiy.Select(f => f.Name))
            .Map(dest => dest.PhotosPaths, src => src.Photos.Select(p => p.Path));
    }
}
