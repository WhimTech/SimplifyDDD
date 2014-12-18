using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;

namespace SimplifyDDD.Config
{
    public sealed class ConfigurationReader
    {
        private static readonly ConfigurationReader _Instance = new ConfigurationReader();
        /// <summary>
        /// Initializes a new instance of <c>Configuration Reader</c> class.
        /// </summary>
        private ConfigurationReader()
        {
        }

        public static ConfigurationReader Instance { get { return _Instance; } }


        Hashtable Configs = new Hashtable();

        public TConfigurationSection GetConfigurationSection<TConfigurationSection>(string name = null)
            where TConfigurationSection : ConfigurationSection
        {
            if (string.IsNullOrEmpty(name))
            {
                var configSectionNameAttr = typeof(TConfigurationSection).GetCustomAttribute<ConfigurationSectionNameAttribute>();
                if (configSectionNameAttr != null)
                {
                    name = configSectionNameAttr.Name;
                }
                if (string.IsNullOrEmpty(name))
                {
                    name = typeof(TConfigurationSection).Name;
                }
            }

            var configSection = Configs[name] as TConfigurationSection;
            if (configSection == null)
            {
                configSection = ConfigurationManager.GetSection(name) as TConfigurationSection;
                Configs[name] = configSection;
            }
            return configSection;
        }
    }
}
