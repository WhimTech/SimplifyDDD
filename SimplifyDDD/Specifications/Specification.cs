using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents the generic version of the base class for all the specifications.
    /// </summary>
    /// <typeparam name="T">The type of the aggregation root.</typeparam>
    public abstract class Specification<T> : ISpecification<T>
      //  where T : class, IEntity
    {

        public static Specification<T> Eval(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }

        #region ISpecification<T> Members

        public virtual bool IsSatisfiedBy(T obj)
        {
            return this.GetExpression().Compile()(obj);
        }

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }

        public ISpecification<T> AndNot(ISpecification<T> other)
        {
            return new AndNotSpecification<T>(this, other);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public abstract Expression<Func<T, bool>> GetExpression();

        #endregion
    }
}
