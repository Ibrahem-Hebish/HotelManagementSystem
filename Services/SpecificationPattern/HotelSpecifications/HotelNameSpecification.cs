using Ardalis.Specification;
using System.Linq.Expressions;

namespace Services.SpecificationPattern.HotelSpecifications;

public class HotelNameSpecification(string name) : ISpecification<Hotel>
{
    public Expression<Func<Hotel, bool>> Filter
    {
        get
        {
            name = name.Trim();
            return p => EF.Functions.Like(p.Name, $"%{name}%");
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
