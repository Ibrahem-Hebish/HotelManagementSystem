namespace Services.SpecificationPattern.RoomSpecifications;

public class RoomIncludeOptions
{
    public bool IncludeHotel { get; private set; } = true;
    public bool IncludePhotos { get; private set; } = false;
    public bool IncludeFacilities { get; private set; } = false;
    public bool IncludeReservations { get; private set; } = false;

    public RoomIncludeOptions WithHotel()
    {
        IncludeHotel = true;
        return this;
    }

    public RoomIncludeOptions WithPhotos()
    {
        IncludePhotos = true;
        return this;
    }

    public RoomIncludeOptions WithFacilities()
    {
        IncludeFacilities = true;
        return this;
    }

    public RoomIncludeOptions WithReservations()
    {
        IncludeReservations = true;
        return this;
    }

    public RoomIncludeOptions None()
    {
        IncludeHotel = false;
        IncludePhotos = false;
        IncludeFacilities = false;
        IncludeReservations = false;
        return this;
    }
}