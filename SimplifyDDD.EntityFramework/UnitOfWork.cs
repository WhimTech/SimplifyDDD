using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Transactions;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Entity Map To Repsoitory
        /// <summary>
        /// 注册实体对应的仓储类型
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="repositoryType"></param>
        public static void RegisterEntityRepository(Type entityType, Type repositoryType)
        {
            EntityRepositoryMap[entityType] = repositoryType;
        }

        /// <summary>
        /// 实体仓储映射表
        /// </summary>
        public static Dictionary<Type, Type> EntityRepositoryMap = new Dictionary<Type, Type>();
        #endregion

        #region Options
        private Hashtable _options = new Hashtable();
        /// <summary>
        /// 设置选项
        /// </summary>
        public Hashtable Options
        {
            get { return _options; }
            set { _options = value; }
        }

        /// <summary>
        /// 添加设置
        /// </summary>
        /// <param name="param">参数表</param>
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

        /// <summary>
        /// 检查延迟加载
        /// </summary>
        private void CheckLazyLoad()
        {
            if (Options.ContainsKey("LazyLoad"))
            {
                foreach (var dbContext in dbContexts)
                {
                    dbContext.Value.Configuration.LazyLoadingEnabled = (bool)Options["LazyLoad"];
                }
            }
        }

        /// <summary>
        /// 添加选项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
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

        /// <summary>
        /// 获取默认领域仓储
        /// </summary>
        /// <returns>领域仓储</returns>
        public IDomainRepository GetDomainRepository()
        {
            var repository = IoCFactory.Resolve<IDomainRepository>();
            repository.Join(this);
            return repository;
        }

        /// <summary>
        /// 根据名称获取领域仓储
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>仓储</returns>
        public IDomainRepository GetDomainRepository(string name)
        {
            var repository = IoCFactory.Resolve<IDomainRepository>(name);
            repository.Join(this);
            return repository;
        }

        /// <summary>
        /// 获取领域仓储
        /// </summary>
        /// <typeparam name="TDomainRespository">领域仓储类型</typeparam>
        /// <returns>领域仓储</returns>
        public IDomainRepository GetDomainRepository<TDomainRespository>() where TDomainRespository : IDomainRepository
        {
            var repository = IoCFactory.Resolve<TDomainRespository>();
            repository.Join(this);
            return repository;
        }

        /// <summary>
        /// 根据名称获取领域仓储
        /// </summary>
        /// <typeparam name="TDomainRespository">领域仓储类型</typeparam>
        /// <param name="name">名称</param>
        /// <returns>领域仓储</returns>
        public IDomainRepository GetDomainRepository<TDomainRespository>(string name) where TDomainRespository : IDomainRepository
        {
            var repository = IoCFactory.Resolve<TDomainRespository>(name);
            repository.Join(this);
            return repository;
        }

        /// <summary>
        /// 仓储实例字典
        /// </summary>
        private Dictionary<Type, IRepository> repositories = new Dictionary<Type, IRepository>();

        /// <summary>
        /// 获取仓储
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <returns>仓储</returns>
        public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class,IAggregateRoot
        {
            IRepository repository = null;
            IRepository<TAggregateRoot> genericRepo = null;
            if (repositories.TryGetValue(typeof(IRepository<TAggregateRoot>), out repository))
            {
                genericRepo = (IRepository<TAggregateRoot>)repository;
            }
            else
            {
                foreach (var entityRepository in EntityRepositoryMap)
                {
                    if (typeof(TAggregateRoot).GetInterfaces().Contains(entityRepository.Key))
                    {
                        repository = (IRepository<TAggregateRoot>)IoCFactory.Resolve(entityRepository.Value.MakeGenericType(typeof(TAggregateRoot)));
                    }
                }
                if (repository == null)
                {
                    repository = IoCFactory.Resolve<IRepository<TAggregateRoot>>();
                }
                repositories.Add(typeof(IRepository<TAggregateRoot>), repository);
                genericRepo = (IRepository<TAggregateRoot>)repository;
                genericRepo.Join(this);
            }
            return genericRepo;
        }

        /// <summary>
        /// 根据名称获取仓储
        /// </summary>
        /// <typeparam name="TAggregateRoot">聚合根类型</typeparam>
        /// <param name="name">名称</param>
        /// <returns>仓储</returns>
        public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>(string name) where TAggregateRoot : class,IAggregateRoot
        {
            IRepository repository = null;
            IRepository<TAggregateRoot> genericRepo = null;
            if (repositories.TryGetValue(typeof(IRepository<TAggregateRoot>), out repository))
            {
                genericRepo = (IRepository<TAggregateRoot>)repository;
            }
            else
            {
                foreach (var entityRepository in EntityRepositoryMap)
                {
                    if (typeof(TAggregateRoot).GetInterfaces().Contains(entityRepository.Key))
                    {
                        repository = (IRepository<TAggregateRoot>)IoCFactory.Resolve(entityRepository.Value.MakeGenericType(typeof(TAggregateRoot)), name);
                    }
                }
                if (repository == null)
                {
                    repository = IoCFactory.Resolve<IRepository<TAggregateRoot>>(name);
                }
                repositories.Add(typeof(IRepository<TAggregateRoot>), repository);
                genericRepo = (IRepository<TAggregateRoot>)repository;
                genericRepo.Join(this);
            }
            return genericRepo;
        }

        TService IUnitOfWork.GetDomainService<TService>()
        {
            //var service = typeof(TService).IsClass ? Activator.CreateInstance<TService>() : IoCFactory.Resolve<TService>();
            var service = IoCFactory.Resolve<TService>();
            this.Joint(service);
            return service;
        }

        TService IUnitOfWork.GetDomainService<TService>(string name)
        {
            //var service = typeof(TService).IsClass ? Activator.CreateInstance<TService>() : IoCFactory.Resolve<TService>(name);
            var service = IoCFactory.Resolve<TService>(name);
            this.Joint(service);
            return service;
        }

        private Dictionary<Type, DbContext> dbContexts = new Dictionary<Type, DbContext>();
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <param name="dbContextType">数据库上下文类型</param>
        /// <returns>数据库上下文</returns>
        public DbContext GetDbContext(Type dbContextType)
        {
            if (!dbContexts.ContainsKey(dbContextType))
            {
                dbContexts[dbContextType] = (DbContext)IoCFactory.Resolve(dbContextType);
            }
            CheckLazyLoad();
            return dbContexts[dbContextType];
        }

        private UnitOfWorkProxy _unitOfWorkProxy = null;
        /// <summary>
        /// 工作单元代理
        /// </summary>
        public UnitOfWorkProxy UnitOfWorkProxy
        {
            get
            {
                if (_unitOfWorkProxy == null)
                {
                    _unitOfWorkProxy = new UnitOfWorkProxy(this);
                }
                return _unitOfWorkProxy;
            }
        }

        /// <summary>
        /// 联合多个工作到同一个工作单元中
        /// </summary>
        /// <param name="works"></param>
        public void Joint(ICollection<IJoinableWork> works)
        {
            foreach (var work in works)
            {
                work.Join(UnitOfWorkProxy);
            }
        }

        public void Joint(params IJoinableWork[] works)
        {
            foreach (var work in works)
            {
                work.Join(UnitOfWorkProxy);
            }
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            var effectRow = 0;
            using (var transaction = new TransactionScope())
            {
                foreach (var dbContext in dbContexts)
                {
                    effectRow += dbContext.Value.SaveChanges();
                }
                //提交事务
                transaction.Complete();
            }
            return effectRow;
        }

    }
}