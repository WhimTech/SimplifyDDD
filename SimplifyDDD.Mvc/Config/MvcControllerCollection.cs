using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SimplifyDDD;

namespace SimplifyDDD.Mvc.Config
{
    [ConfigurationCollection(typeof(MvcControllerElement), AddItemName = "mvcController", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class MvcControllerCollection : BaseConfigurationElementCollection<MvcControllerElement>
    {
      
    }
}
