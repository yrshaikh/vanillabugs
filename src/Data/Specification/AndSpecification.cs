using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Core
{
    public class AndSpecification<T> :CompositeSpecification<T> 
    {
        public AndSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification): base(leftSpecification, rightSpecification)
        {
        }

        public override Expression<Func<T, bool>> GetAllPredicates()
        {
            return LeftSpecification.GetAllPredicates().And(RightSpecification.Predicate);
        }

        #region Implementation of ISpecification<T>

        public override bool IsSatisfiedBy(T entity)
        {
            return LeftSpecification.IsSatisfiedBy(entity) && RightSpecification.IsSatisfiedBy(entity);
        }

        public override IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            var combinedPredicates = LeftSpecification.GetAllPredicates();
            return query.Where(combinedPredicates.And(RightSpecification.Predicate));
        }

        #endregion
    }
}
