using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD;
using SimplifyDDD.Repository;
using Microsoft.Practices.Unity;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntityFramework
{
    public static class ConfigurationExtension
    {
        public static SimplifyDDDConfiguration RegisterEntityFramework(this SimplifyDDDConfiguration simplifyDddConfiguration)
        {
            IoCFactory.Instance.CurrentContainer.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            IoCFactory.Instance.CurrentContainer.RegisterType<IUnitOfWork, UnitOfWork>();
            IoCFactory.Instance.CurrentContainer.RegisterType<IDomainRepository, DomainRepository>();
            return simplifyDddConfiguration;
        }


    }
}
