using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Entity;
using SimplifyDDD.Repository;

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
        TService GetService<TService>() where TService : IJoinable;
        TService GetService<TService>(string name) where TService : IJoinable;
        void Joint(ICollection<IJoinable> works);
        int Commit();
    }
}
