namespace Core.Features.Hotels;

internal static class HotelMapping
{
    public static void Configure()
    {
        TypeAdapterConfig<Hotel, GetHotel>.NewConfig();
    }
}
