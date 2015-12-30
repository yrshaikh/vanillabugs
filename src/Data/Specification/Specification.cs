using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Core
{
    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Predicate;
        private readonly Func<T, bool> _compliedPredicate;

        public Specification(Expression<Func<T, bool>> expression)
        {
            this.Predicate = expression;
            this._compliedPredicate = Predicate.Compile();
        }

        protected Specification()
        {
        }

        public AndSpecification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public OrSpecification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public NotSpecification<T> Not(Specification<T> specification)
        {
            return  new NotSpecification<T>(this,specification);
        }


        #region Implementation of ISpecification<T>

        public virtual Expression<Func<T, bool>> GetAllPredicates()
        {
            return Predicate;
        }

        public virtual bool IsSatisfiedBy(T entity)
        {
            return _compliedPredicate.Invoke(entity);
        }

        public virtual IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            return query.Where(Predicate);
        }

        #endregion
    }
}
