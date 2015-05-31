using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SimplifyDDD.Logging;

namespace SimplifyDDD.EntLibLogging
{
    public class EntLibLoggerFactory : ILoggerFactory
    {
        public ILogger Create()
        {
            return new EntLibLogger(new EntLibLogWriter());
        }

        public ILogger Create(string name)
        {
            return new EntLibLogger(new EntLibLogWriter());
        }

        public ILogger Create(Type type)
        {
            return new EntLibLogger(new EntLibLogWriter());
        }
    }
}
