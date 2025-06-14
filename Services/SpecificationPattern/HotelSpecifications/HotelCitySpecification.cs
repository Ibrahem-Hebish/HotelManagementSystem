using Ardalis.Specification;
using System.Linq.Expressions;

namespace Services.SpecificationPattern.HotelSpecifications;

public class HotelCitySpecification(string city) : ISpecification<Hotel>
{
    public Expression<Func<Hotel, bool>> Filter
    {
        get
        {
            city = city.Trim();
            return p => EF.Functions.Like(p.City, $"%{city}%");
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }


}

