using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents the specification which performs AND assertion
    /// on the two given specifications.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    [Semantics(Semantics.And)]
    public class AndSpecification<T> : CompositeSpecification<T>
      //  where T : class, IEntity
    {
        #region Ctor
        /// <summary>
        /// Constructs a new instance of AndSpecification.
        /// </summary>
        /// <param name="left">The left side of the combined specification.</param>
        /// <param name="right">The right side of the combined specification.</param>
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a LINQ expression which represents the semantics
        /// of the specification.
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        public override Expression<Func<T, bool>> GetExpression()
        {
            //var body = Expression.AndAlso(Left.GetExpression().Body, Right.GetExpression().Body);
            var body = Left.GetExpression().And(Right.GetExpression());
            return Expression.Lambda<Func<T, bool>>(body, Left.GetExpression().Parameters);
        }
        #endregion
    }

}
