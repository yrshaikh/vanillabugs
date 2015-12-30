using System.Linq;

namespace Data.Core
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query);
    }
}
