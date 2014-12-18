using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    internal sealed class ExpressionSpecification<T> : Specification<T>
      //  where T : class, IEntity
    {
        private Expression<Func<T, bool>> expression;

        public ExpressionSpecification(Expression<Func<T, bool>> expression)
        {
            this.expression = expression;
        }

        public override Expression<Func<T, bool>> GetExpression()
        {
            return this.expression;
        }
    }
}
