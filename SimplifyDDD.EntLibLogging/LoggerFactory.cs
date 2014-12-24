using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SimplifyDDD.Logging;

namespace SimplifyDDD.EntLibLogging
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger Create()
        {
            return new Logger(EnterpriseLibraryContainer.Current.GetInstance<LogWriter>());
        }

        public ILogger Create(string name)
        {
            return new Logger(EnterpriseLibraryContainer.Current.GetInstance<LogWriter>(name));
        }

        public ILogger Create(Type type)
        {
            return new Logger((LogWriter)EnterpriseLibraryContainer.Current.GetInstance(type));
        }
    }
}
