using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Core
{
    public class NotSpecification<T>:CompositeSpecification<T>
    {
        public NotSpecification(Specification<T> leftSpecification, Specification<T> rightSpecification)
            : base(leftSpecification,rightSpecification)
        {
            
        }

        public override Expression<Func<T, bool>> GetAllPredicates()
        {
            throw new NotImplementedException();
        }
        
        #region Implementation of ISpecification<T>
        
        public override bool IsSatisfiedBy(T entity)
        {
            return LeftSpecification.IsSatisfiedBy(entity) && !RightSpecification.IsSatisfiedBy(entity);
        }

        public override IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
