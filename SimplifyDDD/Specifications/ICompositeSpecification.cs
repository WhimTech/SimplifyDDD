namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents that the implemented classes are composite specifications.
    /// </summary>
    public interface ICompositeSpecification<T> : ISpecification<T>
    //    where T : class, IEntity
    {
        /// <summary>
        /// Gets the left side of the specification.
        /// </summary>
        ISpecification<T> Left { get; }
        /// <summary>
        /// Gets the right side of the specification.
        /// </summary>
        ISpecification<T> Right { get; }
    }
}
