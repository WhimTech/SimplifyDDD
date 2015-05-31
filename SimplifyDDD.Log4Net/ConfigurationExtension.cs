using Microsoft.Practices.Unity;
using SimplifyDDD;
using SimplifyDDD.Config;
using SimplifyDDD.Logging;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD.Log4Net
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationExtension
    {
        public static SimplifyDDDConfiguration RegisterLog4Net(this SimplifyDDDConfiguration simplifyDddConfiguration)
        {
            IoCFactory.Instance.CurrentContainer.RegisterType<ILoggerFactory, Log4NetLoggerFactory>();
            IoCFactory.Instance.CurrentContainer.RegisterType<ILogWriter, Log4NetLogWriter>();
            return simplifyDddConfiguration;
        }


    }
}
