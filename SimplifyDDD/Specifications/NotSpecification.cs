using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    public class NotSpecification<T> : Specification<T>
     //   where T : class, IEntity
    {
        private ISpecification<T> spec;
        public NotSpecification(ISpecification<T> specification)
        {
            this.spec = specification;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            var body = Expression.Not(this.spec.GetExpression().Body);
            return Expression.Lambda<Func<T, bool>>(body, this.spec.GetExpression().Parameters);
        }
    }

}
