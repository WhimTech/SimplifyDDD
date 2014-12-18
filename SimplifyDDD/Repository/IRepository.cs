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
    public interface IRepository
    {
    }

    public interface IRepository<TAggregateRoot> : IJoinable, IRepository
        where TAggregateRoot : class, IAggregateRoot
    {
        void Add(ICollection<TAggregateRoot> entities);
        void Add(TAggregateRoot entity);
        TAggregateRoot GetByKey(params object[] keyValues);
        long Count(Expression<Func<TAggregateRoot, bool>> specification);
        IQueryable<TAggregateRoot> FindAll();
        IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> specification);
        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification);
        TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, Object>> include);
        IQueryable<TAggregateRoot> Include(Expression<Func<TAggregateRoot, Object>> include);
        bool Exists(Expression<Func<TAggregateRoot, bool>> specification);
        void Remove(TAggregateRoot entity);
        void Remove(IEnumerable<TAggregateRoot> entities);
        void Update(TAggregateRoot entity);
        int Commit();
    }
}
