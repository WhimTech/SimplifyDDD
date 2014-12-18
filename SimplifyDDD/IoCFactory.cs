using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SimplifyDDD.Repository;
using SimplifyDDD.UnitOfWork;

namespace SimplifyDDD
{
    public sealed class IoCFactory
    {
        #region IoCFactory Instance Singleton

        private static readonly IoCFactory instance = new IoCFactory();
        public static IoCFactory Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region Members

        private static readonly IUnityContainer currentContainer;
        public IUnityContainer CurrentContainer
        {
            get
            {
                return currentContainer;
            }
        }

        #endregion

        #region Constructor

        static IoCFactory()
        {
            currentContainer = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
            if (section != null)
            {
                section.Configure(currentContainer);
            }
        }

        public static T Resolve<T>(string name, params ResolverOverride[] overrides)
        {
            return Instance.CurrentContainer.Resolve<T>(name, overrides);
        }

        public static T Resolve<T>(params ResolverOverride[] overrides)
        {
            return Instance.CurrentContainer.Resolve<T>(overrides);
        }

        public static object Resolve(Type type, params ResolverOverride[] overrides)
        {
            return Instance.CurrentContainer.Resolve(type, overrides);
        }

        public static object Resolve(Type type, string name, params ResolverOverride[] overrides)
        {
            return Instance.CurrentContainer.Resolve(type, name, overrides);
        }

        #endregion
    }
}
