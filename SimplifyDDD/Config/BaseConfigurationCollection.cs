using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SimplifyDDD.Config
{
    public class BaseConfigurationElementCollection<TConfigurationElement> : ConfigurationElementCollection
        where TConfigurationElement : ConfigurationElement, new()
    {
        string ConfigurationElementKey { get; set; }

        public BaseConfigurationElementCollection()
        {
            foreach (var p in typeof(TConfigurationElement).GetProperties())
            {
                var configurationProperty = p.GetCustomAttribute<ConfigurationPropertyAttribute>();
                if (configurationProperty != null && configurationProperty.IsKey)
                {
                    ConfigurationElementKey = p.Name;
                    break;
                }
            }
        }

        public TConfigurationElement this[int idx]
        {
            get
            {
                return base.BaseGet(idx) as TConfigurationElement;
            }
            set
            {
                if (base.BaseGet(idx) != null)
                {
                    base.BaseRemoveAt(idx);
                }
                base.BaseAdd(idx, value);
            }
        }



        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TConfigurationElement();
        }

        protected override string ElementName
        {
            get
            {
                return this.GetCustomAttribute<ConfigurationCollectionAttribute>().AddItemName;
            }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return element.GetValueByKey(ConfigurationElementKey);
        }
    }
}
