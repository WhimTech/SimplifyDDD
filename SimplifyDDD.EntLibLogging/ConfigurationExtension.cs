using Microsoft.Practices.Unity;
using SimplifyDDD.Config;
using SimplifyDDD.Logging;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.EntLibLogging
{
    public static class ConfigurationExtension
    {
        public static SimplifyDDDConfiguration RegisterEntLibLogging(this SimplifyDDDConfiguration simplifyDddConfiguration)
        {
            IoCFactory.Instance.CurrentContainer.RegisterType<ILoggerFactory, LoggerFactory>();
            return simplifyDddConfiguration;
        }


    }
}
