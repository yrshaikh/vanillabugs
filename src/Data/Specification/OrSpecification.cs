using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Core
{
    public class OrSpecification<T>: CompositeSpecification<T>
    {
        public OrSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification) : base(leftSpecification,rightSpecification)
        {
        }

        public override Expression<Func<T, bool>> GetAllPredicates()
        {
            return LeftSpecification.GetAllPredicates().Or(RightSpecification.Predicate);
        }

        #region Implementation of ISpecification<T>

        public override bool IsSatisfiedBy(T entity)
        {
            return LeftSpecification.IsSatisfiedBy(entity) || RightSpecification.IsSatisfiedBy(entity);
        }

        public override IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            var combinedPredicates = LeftSpecification.GetAllPredicates();
            return query.Where(combinedPredicates.Or(RightSpecification.Predicate));

            //return query.Where(_leftSpecification.predicate.Or(_rightSpecification.predicate));
        }

        #endregion
    
    }
}
