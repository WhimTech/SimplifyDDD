using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Entity Map To Repsoitory
        public static void RegisterEntityRepository(Type entityType, Type repositoryType)
        {
            EntityRepositoryMap[entityType] = repositoryType;
        }
        public static Dictionary<Type, Type> EntityRepositoryMap = new Dictionary<Type, Type>();
        #endregion

        #region Options
        private Hashtable _options = new Hashtable();

        public Hashtable Options
        {
            get { return _options; }
            set { _options = value; }
        }
        public void AddOptions(Hashtable param)
        {
            foreach (var item in param.Keys)
            {
                if (Options.ContainsKey(item))
                {
                    Options[item] = param[item];
                }
                else
                {
                    Options.Add(item, param[item]);
                }
            }
            CheckLazyLoad();
        }

        public void CheckLazyLoad()
        {
            if (Options.ContainsKey("LazyLoad"))
            {
                foreach (var dbContext in dbContexts)
                {
                    dbContext.Value.Configuration.LazyLoadingEnabled = (bool)Options["LazyLoad"];
                }
            }
        }

        public void AddOption(object key, object value)
        {
            if (Options.ContainsKey(key))
            {
                Options[key] = value;
            }
            else
            {
                Options.Add(key, value);
            }
            CheckLazyLoad();
        }
        #endregion

        public IDomainRepository GetDomainRepository()
        {
            var repository = IoCFactory.Resolve<IDomainRepository>();
            repository.Join(this);
            return repository;
        }

        public IDomainRepository GetDomainRepository(string name)
        {
            var repository = IoCFactory.Resolve<IDomainRepository>(name);
            repository.Join(this);
            return repository;
        }

        public IDomainRepository GetDomainRepository<TDomainRespository>() where TDomainRespository : IDomainRepository
        {
            var repository = IoCFactory.Resolve<TDomainRespository>();
            repository.Join(this);
            return repository;
        }

        public IDomainRepository GetDomainRepository<TDomainRespository>(string name) where TDomainRespository : IDomainRepository
        {
            var repository = IoCFactory.Resolve<TDomainRespository>(name);
            repository.Join(this);
            return repository;
        }

        private Dictionary<Type, IRepository> repositories = new Dictionary<Type, IRepository>();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class,IAggregateRoot
        {
            IRepository repository = null;
            IRepository<TEntity> genericRepo = null;
            if (repositories.TryGetValue(typeof(IRepository<TEntity>), out repository))
            {
                genericRepo = (IRepository<TEntity>)repository;
            }
            else
            {
                foreach (var entityRepository in EntityRepositoryMap)
                {
                    if (typeof(TEntity).GetInterfaces().Contains(entityRepository.Key))
                    {
                        repository = (IRepository<TEntity>)IoCFactory.Resolve(entityRepository.Value.MakeGenericType(typeof(TEntity)));
                    }
                }
                if (repository == null)
                {
                    repository = IoCFactory.Resolve<IRepository<TEntity>>();
                }
                repositories.Add(typeof(IRepository<TEntity>), repository);
                genericRepo = (IRepository<TEntity>)repository;
                genericRepo.Join(this);
            }
            return genericRepo;
        }

        public IRepository<TEntity> GetRepository<TEntity>(string name) where TEntity : class,IAggregateRoot
        {
            IRepository repository = null;
            IRepository<TEntity> genericRepo = null;
            if (repositories.TryGetValue(typeof(IRepository<TEntity>), out repository))
            {
                genericRepo = (IRepository<TEntity>)repository;
            }
            else
            {
                foreach (var entityRepository in EntityRepositoryMap)
                {
                    if (typeof(TEntity).GetInterfaces().Contains(entityRepository.Key))
                    {
                        repository = (IRepository<TEntity>)IoCFactory.Resolve(entityRepository.Value.MakeGenericType(typeof(TEntity)), name);
                    }
                }
                if (repository == null)
                {
                    repository = IoCFactory.Resolve<IRepository<TEntity>>(name);
                }
                repositories.Add(typeof(IRepository<TEntity>), repository);
                genericRepo = (IRepository<TEntity>)repository;
                genericRepo.Join(this);
            }
            return genericRepo;
        }

        public TService GetService<TService>() where TService : IJoinable
        {
            var service = typeof(TService).IsClass ? Activator.CreateInstance<TService>() : IoCFactory.Resolve<TService>();
            service.Join(this);
            return service;
        }

        public TService GetService<TService>(string name) where TService : IJoinable
        {
            var service = typeof(TService).IsClass ? Activator.CreateInstance<TService>() : IoCFactory.Resolve<TService>(name);
            service.Join(this);
            return service;
        }


        private Dictionary<Type, DbContext> dbContexts = new Dictionary<Type, DbContext>();
        public DbContext GetDbContext(Type dbContextType)
        {
            if (!dbContexts.ContainsKey(dbContextType))
            {
                dbContexts[dbContextType] = (DbContext)IoCFactory.Resolve(dbContextType);
            }
            CheckLazyLoad();
            return dbContexts[dbContextType];
        }

        public void Joint(ICollection<IJoinable> works)
        {
            foreach (var work in works)
            {
                work.Join(this);
            }
        }

        public int Commit()
        {
            var effectRow = 0;
            foreach (var dbContext in dbContexts)
            {
                effectRow += dbContext.Value.SaveChanges();
            }
            return effectRow;
        }

    }
}