using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    public sealed class NoneSpecification<T> : Specification<T>
      //  where T : class, IEntity
    {
        public override Expression<Func<T, bool>> GetExpression()
        {
            return o => false;
        }
    }
}
