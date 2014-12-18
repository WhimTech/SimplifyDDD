namespace SimplifyDDD.Specifications
{
    /// <summary>
    /// Represents 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecificationParser<T>
    {
        T Parse<TEntity>(ISpecification<TEntity> specification);
         //   where TEntity : class, IEntity;
    }
}
