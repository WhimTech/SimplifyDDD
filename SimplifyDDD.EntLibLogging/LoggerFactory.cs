using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplifyDDD.Logging;

namespace SimplifyDDD.EntLibLogging
{
    public class LoggerFactory:ILoggerFactory
    {
        public ILogger Create(string name)
        {
            throw new NotImplementedException();
        }

        public ILogger Create(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
