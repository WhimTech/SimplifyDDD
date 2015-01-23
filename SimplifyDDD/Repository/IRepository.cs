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
    /// 仓储
    /// </summary>
    public interface IRepository : IJoinable
    {
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
    public interface IRepository<TAggregateRoot> : IRepository where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// 添加聚合根
        /// </summary>
        /// <param name="entities">聚合根实体集合</param>
        void Add(ICollection<TAggregateRoot> entities);

        /// <summary>
        /// 添加聚合根
        /// </summary>
        /// <param name="entity">聚合根实体</param>
        void Add(TAggregateRoot entity);

        /// <summary>
        /// 根据主键获取聚合根
        /// </summary>
        /// <param name="keyValues">主键</param>
        /// <returns>聚合根实体</returns>
        TAggregateRoot GetByKey(params object[] keyValues);

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <returns>数量</returns>
        long Count();

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>数量</returns>
        long Count(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 查询全部聚合根
        /// </summary>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> FindAll();

        /// <summary>
        /// 查询全部聚合根
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 查询单个聚合根
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>聚合根对象</returns>
        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 查询单个聚合根
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="include">包含</param>
        /// <returns>聚合根对象</returns>
        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> predicate, Expression<Func<TAggregateRoot, Object>> include);

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="include">包含</param>
        /// <returns>聚合根集合</returns>
        IQueryable<TAggregateRoot> Include(Expression<Func<TAggregateRoot, Object>> include);

        /// <summary>
        /// 查询聚合根是否存在
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>是否存在</returns>
        bool Exists(Expression<Func<TAggregateRoot, bool>> predicate);

        /// <summary>
        /// 移除聚合根
        /// </summary>
        /// <param name="entity">聚合根对象</param>
        void Remove(TAggregateRoot entity);

        /// <summary>
        /// 基础聚合根
        /// </summary>
        /// <param name="entities">聚合根集合</param>
        void Remove(IEnumerable<TAggregateRoot> entities);

        /// <summary>
        /// 更新聚合根
        /// </summary>
        /// <param name="entity">聚合根</param>
        void Update(TAggregateRoot entity);

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns>影响行数</returns>
        int Commit();
    }
}
