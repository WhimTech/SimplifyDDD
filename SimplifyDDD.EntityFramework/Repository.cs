using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    public class Repository<TAggregateRoot> : BaseDomainService, IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        public Repository()
        {

        }

        public Repository(DbContext dbContext)
        {
            DbContextType = dbContext.GetType();
        }

        public DbContext DbContext
        {
            get
            {
                var unitOfWork = UnitOfWork as UnitOfWork;
                if (DbContextType == null)
                {
                    DbContextType = typeof(DbContext);
                }
                return unitOfWork.GetDbContext(DbContextType);
            }
        }
        public Type DbContextType { get; set; }

        public virtual IQueryable<TAggregateRoot> Entities
        {
            get
            {
                return DbSet;
            }
        }

        DbSet<TAggregateRoot> _objectSet;
        public DbSet<TAggregateRoot> DbSet
        {
            get
            {
                if (_objectSet == null)
                {
                    _objectSet = DbContext.Set<TAggregateRoot>();
                }
                return _objectSet;
            }
        }

        public virtual void Add(ICollection<TAggregateRoot> entities)
        {
            DbSet.AddRange(entities);
        }

        public virtual void Add(TAggregateRoot entity)
        {
            DbSet.Add(entity);
        }

        public virtual TAggregateRoot GetByKey(params object[] keyValues)
        {
            return DbSet.Find(keyValues);
        }

        public virtual IQueryable<TAggregateRoot> GetAll()
        {
            return DbSet;
        }

        public virtual long Count(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual IQueryable<TAggregateRoot> FindAll()
        {
            return DbSet;
        }

        public virtual IQueryable<TAggregateRoot> FindAll(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public virtual TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual TAggregateRoot Find(Expression<Func<TAggregateRoot, bool>> predicate, Expression<Func<TAggregateRoot, Object>> include)
        {
            return DbSet.Include(include).FirstOrDefault(predicate);
        }

        public virtual IQueryable<TAggregateRoot> Include(Expression<Func<TAggregateRoot, Object>> include)
        {
            return DbSet.Include(include);
        }

        public virtual bool Exists(Expression<Func<TAggregateRoot, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public virtual void Remove(TAggregateRoot entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Remove(IEnumerable<TAggregateRoot> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void Update(TAggregateRoot entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual IQueryable<TAggregateRoot> PageFind(int pageIndex, int pageSize,
            Expression<Func<TAggregateRoot, bool>> specification)
        {
            return DbSet.Where(specification).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual IQueryable<TAggregateRoot> PageFind(int pageIndex, int pageSize,
            Expression<Func<TAggregateRoot, bool>> specification, ref long totalCount)
        {
            totalCount = Count(specification);
            return DbSet.Where(specification).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        public virtual int Commit()
        {
            if (IsJointed)
            {
                throw new Exception("This work is joined!");
            }
            return DbContext.SaveChanges();
        }
    }
}
