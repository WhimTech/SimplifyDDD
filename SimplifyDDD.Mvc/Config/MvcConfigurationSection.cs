using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SimplifyDDD;
using SimplifyDDD.Config;

namespace SimplifyDDD.Mvc.Config
{
    [ConfigurationSectionName("mvcConfiguration")]
    public class MvcConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("mvcControllers", IsRequired = false)]
        public MvcControllerCollection MvcControllers
        {
            get { return (MvcControllerCollection)base["mvcControllers"]; }
            set { base["mvcControllers"] = value; }
        }
    }
}
