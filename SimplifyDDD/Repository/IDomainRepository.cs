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
    public interface IDomainRepository : IRepository, IJoinable
    {
        void Add<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot;

        void Add<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        TAggregateRoot GetByKey<TAggregateRoot>(params object[] keyValues) where TAggregateRoot : class, IAggregateRoot;

        long Count<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        long Count<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> FindAll<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot;

        TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot;

        IQueryable<TAggregateRoot> Include<TAggregateRoot>(Expression<Func<TAggregateRoot, Object>> include) where TAggregateRoot : class, IAggregateRoot;

        bool Exists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot;

        void Remove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        void Remove<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot;

        void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot;

        int Commit();
    }
}
