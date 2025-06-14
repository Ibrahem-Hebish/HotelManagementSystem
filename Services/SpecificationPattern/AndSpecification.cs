using System.Linq.Expressions;

namespace Services.SpecificationPattern;

public class AndSpecification<T>(ISpecification<T> left, ISpecification<T> right) : ISpecification<T>
    where T : class
{
    public Expression<Func<T, bool>> Filter
    {
        get
        {
            var leftFilter = left.Filter;
            var rightFilter = right.Filter;

            if (leftFilter is null || rightFilter is null)
            {
                throw new InvalidOperationException("Both specifications must have a filter defined.");
            }

            var param = Expression.Parameter(typeof(T));

            var whereBody = Expression.AndAlso(
                               Expression.Invoke(leftFilter, param),
                                              Expression.Invoke(rightFilter, param)
                                                         );

            return Expression.Lambda<Func<T, bool>>(whereBody, param);
        }
        set => throw new NotImplementedException("Filter is read-only in this specification.");
    }
}
