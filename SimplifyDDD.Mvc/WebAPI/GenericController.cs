using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SimplifyDDD.Entity;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.Mvc.WebAPI
{
    public class GenericController<TEntity> : ApiController where TEntity : class, IAggregateRoot
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public GenericController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UnitOfWork.AddOption("LazyLoad", false);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return UnitOfWork.GetRepository<TEntity>().FindAll(ent => true).ToList();
        }

        public virtual TEntity Get(Guid id)
        {
            return UnitOfWork.GetRepository<TEntity>().GetByKey(id);
        }

        // POST api/values
        public virtual void Post([FromBody]TEntity item)
        {
            UnitOfWork.GetRepository<TEntity>().Add(item);
            UnitOfWork.Commit();
        }

        // PUT api/values/5
        public virtual void Put(Guid id, [FromBody]TEntity item)
        {
            UnitOfWork.GetRepository<TEntity>().Update(item);
            UnitOfWork.Commit();
        }

        // DELETE api/values/5
        public virtual void Delete(Guid id)
        {
            var repository = UnitOfWork.GetRepository<TEntity>();
            repository.Remove(repository.GetByKey(id));
            UnitOfWork.Commit();
        }
    }
}
