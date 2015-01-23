namespace SimplifyDDD.Entity
{
    /// <summary>
    /// 聚合根
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
    }

    /// <summary>
    /// 聚合更
    /// </summary>
    /// <typeparam name="TKey">主键</typeparam>
    public interface IAggregateRoot<TKey> : IAggregateRoot, IEntity<TKey>
    {
    }
}