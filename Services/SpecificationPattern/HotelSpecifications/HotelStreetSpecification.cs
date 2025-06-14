using System.Linq.Expressions;

namespace Services.SpecificationPattern.HotelSpecifications;


public class HotelStreetSpecification(string street) : ISpecification<Hotel>
{
    public Expression<Func<Hotel, bool>> Filter
    {
        get
        {
            street = street.Trim();
            return p => EF.Functions.Like(p.Street, $"%{street}%");
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
