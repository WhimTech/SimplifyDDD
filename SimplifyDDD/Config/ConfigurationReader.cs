using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;

namespace SimplifyDDD.Config
{
    /// <summary>
    /// 配置读取器
    /// </summary>
    public sealed class ConfigurationReader
    {
        private static readonly ConfigurationReader _Instance = new ConfigurationReader();
        /// <summary>
        /// Initializes a new instance of <c>Configuration Reader</c> class.
        /// </summary>
        private ConfigurationReader()
        {
        }

        /// <summary>
        /// 配置节读取器实例（单例）
        /// </summary>
        public static ConfigurationReader Instance { get { return _Instance; } }


        Hashtable Configs = new Hashtable();

        /// <summary>
        /// 获取配置节
        /// </summary>
        /// <param name="name">配置节名</param>
        /// <typeparam name="TConfigurationSection">配置节泛型</typeparam>
        /// <returns>配置节</returns>
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
