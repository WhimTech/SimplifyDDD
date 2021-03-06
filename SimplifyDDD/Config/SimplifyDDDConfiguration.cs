﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.IO;
using System.Xml.Linq;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace SimplifyDDD.Config
{
    /// <summary>
    /// SimplifyDDD配置
    /// </summary>
    public class SimplifyDDDConfiguration
    {
        /// <summary>
        /// SimplifyDDD配置实例（单例）
        /// </summary>
        public static readonly SimplifyDDDConfiguration Instance = new SimplifyDDDConfiguration();

        /// <summary>
        /// Unity配置节
        /// </summary>
        public UnityConfigurationSection UnityConfigurationSection
        {
            get
            {
                return (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            }
        }

        SimplifyDDDConfiguration()
        {
        }

        /// <summary>
        /// 获取应用配置
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetAppConfig<T>(string key)
        {
            T val = default(T);
            try
            {
                var value = GetAppConfig(key);
                if (typeof(T).IsEquivalentTo(typeof(Guid)))
                {
                    val = (T)Convert.ChangeType(new Guid(value), typeof(T));
                }
                else
                {
                    val = (T)Convert.ChangeType(value, typeof(T));
                }
            }
            catch (Exception)
            {

            }
            return val;
        }

        /// <summary>
        /// 获取应用配置
        /// </summary>
        /// <param name="keyname">键</param>
        /// <param name="configPath">配置路径</param>
        /// <returns>配置属性值</returns>
        public static string GetAppConfig(string keyname, string configPath = "Config")
        {
            var config = System.Configuration.ConfigurationManager.AppSettings[keyname];
            try
            {
                if (string.IsNullOrWhiteSpace(config))
                {
                    string filePath = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, configPath);
                    using (TextReader reader = new StreamReader(filePath))
                    {
                        XElement xml = XElement.Load(filePath);
                        if (xml != null)
                        {
                            var element = xml.Elements().SingleOrDefault(e => e.Attribute("key") != null && e.Attribute("key").Value.Equals(keyname));
                            if (element != null)
                            {
                                config = element.Attribute("value").Value;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                config = string.Empty;
            }
            return config;
        }

    }
}
