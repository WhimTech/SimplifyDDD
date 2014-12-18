using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents the specification which performs AND NOT assertion
    /// on the two given specifications.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    [Semantics(Semantics.AndNot)]
    public class AndNotSpecification<T> : CompositeSpecification<T>
     //   where T : class, IEntity
    {
        #region Ctor
        /// <summary>
        /// Constructs a new instance of AndNotSpecification.
        /// </summary>
        /// <param name="left">The left side of the combined specification.</param>
        /// <param name="right">The right side of the combined specification.</param>
        public AndNotSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a LINQ expression which represents the semantics
        /// of the specification.
        /// </summary>
        /// <returns>The LINQ expression.</returns>
        public override Expression<Func<T, bool>> GetExpression()
        {
            var bodyNot = Expression.Lambda<Func<T, bool>>(Expression.Not(Right.GetExpression().Body));
            //var body = Expression.And(Left.GetExpression().Body, bodyNot);
            var body = Left.GetExpression().And(bodyNot);
            return Expression.Lambda<Func<T, bool>>(body, Left.GetExpression().Parameters);
        }
        #endregion
    }
}
