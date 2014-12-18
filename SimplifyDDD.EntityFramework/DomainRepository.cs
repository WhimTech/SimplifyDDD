using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    public class DomainRepository : BaseService, IDomainRepository
    {
        public DomainRepository()
        {

        }

        public DomainRepository(DbContext dbContext)
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

        internal DbSet<TAggregateRoot> GetRepository<TAggregateRoot>()
            where TAggregateRoot : class,IAggregateRoot
        {
            return DbContext.Set<TAggregateRoot>();
        }


        #region IRepository Members


        public void Add<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot
        {
            //GetRepository<TAggregateRoot>().Add(entities);
            GetRepository<TAggregateRoot>().AddRange(entities);
        }

        public void Add<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Add(entity);
        }

        public TAggregateRoot GetByKey<TAggregateRoot>(params object[] keyValues) where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().GetByKey(keyValues);
            return GetRepository<TAggregateRoot>().Find(keyValues);
        }

        public long Count<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Count();
        }

        public long Count<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Count(specification);
        }

        public IQueryable<TAggregateRoot> GetAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().FindAll();
            return GetRepository<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> FindAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().FindAll();
            return GetRepository<TAggregateRoot>();
        }

        public IQueryable<TAggregateRoot> FindAll<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().FindAll(specification);
            return GetRepository<TAggregateRoot>().Where(specification);
        }

        public TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            //return UnitOfWork.GetRepository<TAggregateRoot>().Find(specification);
            return GetRepository<TAggregateRoot>().FirstOrDefault(specification);
        }

        public TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, Object>> include) where TAggregateRoot : class, IAggregateRoot
        {
            //return UnitOfWork.GetRepository<TAggregateRoot>().Find(specification);
            return GetRepository<TAggregateRoot>().Include(include).FirstOrDefault(specification);
        }

        public bool Exists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().Exists(specification);
            return GetRepository<TAggregateRoot>().Any(specification);
        }

        public virtual IQueryable<TAggregateRoot> Include<TAggregateRoot>(Expression<Func<TAggregateRoot, Object>> include) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Include(include);
        }

        public void Remove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Remove(entity);
        }

        public void Remove<TAggregateRoot>(ICollection<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot
        {
            //GetRepository<TAggregateRoot>().Remove(entities);
            GetRepository<TAggregateRoot>().RemoveRange(entities);
        }

        public void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            //GetRepository<TAggregateRoot>().Update(entity);
            GetRepository<TAggregateRoot>().AddOrUpdate(entity);
        }

        public IQueryable<TAggregateRoot> PageFind<TAggregateRoot, TKey>(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> specification, Expression<Func<TAggregateRoot, TKey>> orderExpression) where TAggregateRoot : class, IAggregateRoot
        {
            if (pageIndex < 0)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageCount");

            if (orderExpression == null)
                throw new ArgumentNullException("orderExpression");

            //return GetRepository<TAggregateRoot>().PageFind(pageIndex, pageSize, specification);
            var result = GetRepository<TAggregateRoot>().Where(specification);
            var orderedResult = result.OrderBy(orderExpression);
            return orderedResult.Skip((pageIndex) * pageSize).Take(pageSize);
        }

        public IQueryable<TAggregateRoot> PageFind<TAggregateRoot>(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> specification, ref long totalCount, Expression<Func<TAggregateRoot, dynamic>> orderExpression) where TAggregateRoot : class, IAggregateRoot
        {
            //return GetRepository<TAggregateRoot>().PageFind(pageIndex, pageSize, specification, ref totalCount);
            if (pageIndex < 0)
                throw new ArgumentException("InvalidPageIndex");

            if (pageSize <= 0)
                throw new ArgumentException("InvalidPageCount");

            if (orderExpression == null)
                throw new ArgumentNullException("orderExpression");

            //return GetRepository<TAggregateRoot>().PageFind(pageIndex, pageSize, specification);
            var result = GetRepository<TAggregateRoot>().Where(specification);
            var orderedResult = result.OrderBy(orderExpression);
            totalCount = orderedResult.Count();
            return orderedResult.Skip((pageIndex) * pageSize).Take(pageSize);
        }

        public PageModel<object> PageFind<TAggregateRoot, TResult, TKey>(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> specification,
            ref long totalCount, Expression<Func<TAggregateRoot, TResult>> selector, Expression<Func<TAggregateRoot, TKey>> orderExpression) where TAggregateRoot : class, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public virtual int Commit()
        {
            if (IsJointed)
            {
                throw new Exception("This work is joined!");
            }
            return DbContext.SaveChanges();
        }
        #endregion

        /*internal IRepository<TAggregateRoot> GetRepository<TAggregateRoot>()
            where TAggregateRoot : class,IAggregateRoot
        {
            return UnitOfWork.GetRepository<TAggregateRoot>();
        }


        #region IRepository Members


        public void Add<TAggregateRoot>(IQueryable<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Add(entities);
        }

        public void Add<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Add(entity);
        }

        public TAggregateRoot GetByKey<TAggregateRoot>(params object[] keyValues) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().GetByKey(keyValues);
        }

        public long Count<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Count(specification);
        }

        public IQueryable<TAggregateRoot> FindAll<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().FindAll();
        }

        public IQueryable<TAggregateRoot> FindAll<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().FindAll(specification);
        }

        public TAggregateRoot Find<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Find(specification);
        }

        public bool Exists<TAggregateRoot>(Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().Exists(specification);
        }

        public void Remove<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Remove(entity);
        }

        public void Remove<TAggregateRoot>(IEnumerable<TAggregateRoot> entities) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Remove(entities);
        }

        public void Update<TAggregateRoot>(TAggregateRoot entity) where TAggregateRoot : class, IAggregateRoot
        {
            GetRepository<TAggregateRoot>().Update(entity);
        }

        public IQueryable<TAggregateRoot> PageFind<TAggregateRoot>(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> specification) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().PageFind(pageIndex, pageSize, specification);
        }

        public IQueryable<TAggregateRoot> PageFind<TAggregateRoot>(int pageIndex, int pageSize, Expression<Func<TAggregateRoot, bool>> specification, ref long totalCount) where TAggregateRoot : class, IAggregateRoot
        {
            return GetRepository<TAggregateRoot>().PageFind(pageIndex, pageSize, specification, ref totalCount);
        }

        public virtual int Commit()
        {
            if (IsJointed)
            {
                throw new Exception("This work is joined!");
            }
            return DbContext.SaveChanges();
        }

        #endregion*/

    }
}
