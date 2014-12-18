using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SimplifyDDD.Mvc.Config
{
    public class MvcControllerElement : ConfigurationElement
    {
        [ConfigurationProperty("assembly", IsRequired = true, IsKey = true)]
        public string Assembly
        {
            get { return (string)base["assembly"]; }
            set { base["assembly"] = value; }
        }
       
    }
}
