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
        /// 获取数量
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <returns>数量</returns>
        long Count<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="predicate">查询条件</param>
        /// <returns>数量</returns>
        long Count<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> predicate) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 查询全部聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 查询全部聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="percidate">查询条件</param>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 查询单个聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="percidate">查询条件</param>
        /// <returns>聚合根对象</returns>
        TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 包含
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="include">包含</param>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> Include<TAggregateRoot>(Expression<Func<TAggregateRoot, Object>> include) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 查询聚合根是否存在
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="percidate">查询条件</param>
        /// <returns>是否存在</returns>
        bool Exists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> percidate) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 移除聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="entity">聚合根对象</param>
        void Remove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 移除聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="entities">聚合根集合</param>
        void Remove<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 更新聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="entity">聚合根对象</param>
        void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns>影响行数</returns>
        int Commit();
    }
}
