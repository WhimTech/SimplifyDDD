using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifyDDD.Config
{
    /// <summary>
    /// 配置节属性
    /// </summary>
    public class ConfigurationSectionNameAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">配置节属性名</param>
        public ConfigurationSectionNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 配置节属性名
        /// </summary>
        public string Name { get; set; }
    }
}
