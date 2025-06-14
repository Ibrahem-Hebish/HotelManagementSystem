using Ardalis.Specification;
using System.Linq.Expressions;

namespace Services.SpecificationPattern.HotelSpecifications;

public class HotelCountrySpecification(string country) : ISpecification<Hotel>
{
    public Expression<Func<Hotel, bool>> Filter
    {
        get
        {
            country = country.Trim();
            return p => EF.Functions.Like(p.Country, $"%{country}%");
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}