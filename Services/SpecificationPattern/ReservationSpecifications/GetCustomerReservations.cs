using System.Linq.Expressions;

namespace Services.SpecificationPattern.ReservationSpecifications;

public class GetCustomerReservationsSpecification(string customerId) : ISpecification<Reservation>
{
    public Expression<Func<Reservation, bool>> Filter
    {
        get =>
            h => h.CustomerId == customerId;

        set => throw new NotImplementedException("Filter is read-only in this specification.");

    }
}

public class ReservationIncludeOptions
{
    public bool IncludeRoom { get; set; } = true;
    public bool IncludeHotel { get; set; } = true;
    public bool IncludeCustomer { get; set; } = true;

    public ReservationIncludeOptions WithRoom()
    {
        IncludeRoom = true;
        return this;
    }

    public ReservationIncludeOptions WithHotel()
    {
        IncludeHotel = true;
        return this;
    }

    public ReservationIncludeOptions WithCustomer()
    {
        IncludeCustomer = true;
        return this;
    }

    public ReservationIncludeOptions None()
    {
        IncludeRoom = false;
        IncludeHotel = false;
        IncludeCustomer = false;
        return this;
    }
}
