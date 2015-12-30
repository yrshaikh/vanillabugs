using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Core
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        public readonly Specification<T> LeftSpecification;
        public readonly Specification<T> RightSpecification;

        protected CompositeSpecification(Specification<T> leftSide, Specification<T> rightSide)
        {
            LeftSpecification= leftSide;
            RightSpecification = rightSide;
        }

        public override abstract bool IsSatisfiedBy(T entity);

        public abstract override Expression<Func<T, bool>> GetAllPredicates();

        public override abstract IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query);
    }
}