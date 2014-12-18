namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents the base class for all the composite specifications.
    /// </summary>
    public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>
      //  where T : class, IEntity
    {
        #region Private Fields
        private ISpecification<T> left;
        private ISpecification<T> right;
        #endregion

        #region Ctor
        /// <summary>
        /// Constructs a new instance of the composite specification.
        /// </summary>
        /// <param name="left">The left side of the specification.</param>
        /// <param name="right">The right side of the specification.</param>
        public CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.left = left;
            this.right = right;
        }
        #endregion

        #region ICompositeSpecification Members
        /// <summary>
        /// Gets the left side of the specification.
        /// </summary>
        public ISpecification<T> Left
        {
            get { return this.left; }
        }
        /// <summary>
        /// Gets the right side of the specification.
        /// </summary>
        public ISpecification<T> Right
        {
            get { return this.right; }
        }

        #endregion

    }

}
