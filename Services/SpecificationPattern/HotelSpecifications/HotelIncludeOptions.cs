namespace Services.SpecificationPattern.HotelSpecifications;

public class HotelIncludeOptions
{
    public bool IncludeRooms { get; private set; }
    public bool IncludeCustomers { get; private set; }
    public bool IncludeEvaluations { get; private set; }
    public bool IncludeReservations { get; private set; }

    public HotelIncludeOptions None()
    {
        IncludeRooms = false;
        IncludeCustomers = false;
        IncludeEvaluations = false;
        IncludeReservations = false;

        return this;
    }

    public HotelIncludeOptions WithRooms()
    {
        IncludeRooms = true;
        return this;
    }

    public HotelIncludeOptions WithCustomers()
    {
        IncludeCustomers = true;
        return this;
    }

    public HotelIncludeOptions WithEvaluations()
    {
        IncludeEvaluations = true;
        return this;
    }

    public HotelIncludeOptions WithReservations()
    {
        IncludeReservations = true;
        return this;
    }
}
