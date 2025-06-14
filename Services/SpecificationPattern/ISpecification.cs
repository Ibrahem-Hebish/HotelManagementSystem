using System.Linq.Expressions;

namespace Services.SpecificationPattern;

public interface ISpecification<T>
{
    public Expression<Func<T, bool>> Filter { get; protected set; }
}
