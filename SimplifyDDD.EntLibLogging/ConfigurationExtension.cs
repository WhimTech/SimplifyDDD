using Microsoft.Practices.Unity;
using SimplifyDDD.Config;
using SimplifyDDD.Logging;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntLibLogging
{
    public static class ConfigurationExtension
    {
        public static SimplifyDDDConfiguration RegisterLogging(this SimplifyDDDConfiguration simplifyDddConfiguration)
        {
            IoCFactory.Instance.CurrentContainer.RegisterType<ILogger, Logger>();
            return simplifyDddConfiguration;
        }


    }
}
