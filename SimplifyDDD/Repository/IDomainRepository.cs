using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.Repository
{
    /// <summary>
    /// 领域仓储
    /// </summary>
    public interface IDomainRepository : IRepository
    {
        /// <summary>
        /// 添加聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="entities">聚合根集合</param>
        void Add<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 添加聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="entity">实体</param>
        void Add<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 根据主键获取聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="keyValues">主键</param>
        /// <returns>聚合根对象</returns>
        TAggregateRoot GetByKey<TAggregateRoot>(params object[] keyValues) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <returns></returns>
        long Count<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        long Count<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> predicate) where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> Include<TAggregateRoot>(Expression<Func<TAggregateRoot, Object>> include) where TAggregateRoot : class, IAggregateRoot;

        bool Exists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        void Remove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        void Remove<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot;

        void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        int Commit();
    }
}
