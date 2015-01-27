using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    public class UnitOfWorkProxy : IUnitOfWork
    {
        private IUnitOfWork _unitOfWork;
        public UnitOfWorkProxy(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddOptions(Hashtable param)
        {
            _unitOfWork.AddOptions(param);
        }

        public void AddOption(object key, object value)
        {
            _unitOfWork.AddOption(key,value);
        }

        public Hashtable Options { get; set; }
        public IDomainRepository GetDomainRepository()
        {
            return _unitOfWork.GetDomainRepository();
        }

        public IDomainRepository GetDomainRepository(string name)
        {
            return _unitOfWork.GetDomainRepository(name);
        }

        public IDomainRepository GetDomainRepository<TDomainRespository>() where TDomainRespository : IDomainRepository
        {
            return _unitOfWork.GetDomainRepository<TDomainRespository>();
        }

        public IDomainRepository GetDomainRepository<TDomainRespository>(string name) where TDomainRespository : IDomainRepository
        {
            return _unitOfWork.GetDomainRepository<TDomainRespository>(name);
        }

        public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot
        {
            return _unitOfWork.GetRepository<TAggregateRoot>();
        }

        public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>(string name) where TAggregateRoot : class, IAggregateRoot
        {
            return _unitOfWork.GetRepository<TAggregateRoot>(name);
        }

        public TService GetDomainService<TService>() where TService : IDomainService
        {
            return _unitOfWork.GetDomainService<TService>();
        }

        public TService GetDomainService<TService>(string name) where TService : IDomainService
        {
            return _unitOfWork.GetDomainService<TService>(name);
        }

        public void Joint(ICollection<IJoinableWork> works)
        {
            _unitOfWork.Joint(works);
        }

        public void Joint(params IJoinableWork[] works)
        {
            _unitOfWork.Joint(works);
        }

        public int Commit()
        {
            //do nothing
            return 0;
        }
    }
}
