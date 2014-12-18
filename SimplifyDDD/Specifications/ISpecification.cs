using System;
using System.Linq.Expressions;

namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents a generic version that the implemented classes are specifications.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface ISpecification<T>
     //   where T : class, IEntity
    {
        /// <summary>
        /// Returns a boolean value which indicates that the specification
        /// is satisfied by the given entity.
        /// </summary>
        /// <param name="obj">The entity to check against the specification.</param>
        /// <returns>True if the specification is satisfied, otherwise false.</returns>
        bool IsSatisfiedBy(T obj);

        ISpecification<T> And(ISpecification<T> other);

        ISpecification<T> Or(ISpecification<T> other);

        ISpecification<T> AndNot(ISpecification<T> other);

        ISpecification<T> Not();

        Expression<Func<T, bool>> GetExpression();
    }
}
