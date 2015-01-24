using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;

namespace SimplifyDDD.UnitOfWork
{
    /// <summary>
    ///     业务单元操作接口
    /// </summary>
    public interface IUnitOfWork
    {
        #region 配置
        void AddOptions(Hashtable param);
        void AddOption(object key, object value);
        Hashtable Options { get; set; }
        #endregion

        IDomainRepository GetDomainRepository();
        IDomainRepository GetDomainRepository(string name);
        IDomainRepository GetDomainRepository<TDomainRespository>() where TDomainRespository : IDomainRepository;
        IDomainRepository GetDomainRepository<TDomainRespository>(string name) where TDomainRespository : IDomainRepository;
        IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : class, IAggregateRoot;
        IRepository<TAggregateRoot> GetRepository<TAggregateRoot>(string name) where TAggregateRoot : class, IAggregateRoot;
        TService GetDomainService<TService>() where TService : IDomainService;
        TService GetDomainService<TService>(string name) where TService : IDomainService;
        void Joint(ICollection<IJoinableWork> works);
        void Joint(params IJoinableWork[] works);
        int Commit();
    }
}
