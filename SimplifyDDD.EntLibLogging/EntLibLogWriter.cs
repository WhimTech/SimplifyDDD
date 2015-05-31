using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using SimplifyDDD.Logging;

namespace SimplifyDDD.EntLibLogging
{
    public class EntLibLogWriter : LogWriter, ILogWriter
    {
        private LogWriter LogWriter { get; set; }
        public EntLibLogWriter()
        {
            LogWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
        }

        public EntLibLogWriter(string name)
        {
            LogWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>(name);
        }

        public EntLibLogWriter(Type type)
        {
            LogWriter = (LogWriter)EnterpriseLibraryContainer.Current.GetInstance(type);
        }

        public void Write(ILogEntry log)
        {
            LogWriter.Write(log);
        }

        public override T GetFilter<T>()
        {
            return LogWriter.GetFilter<T>();
        }

        public override T GetFilter<T>(string name)
        {
            return LogWriter.GetFilter<T>(name);
        }

        public override ILogFilter GetFilter(string name)
        {
            return LogWriter.GetFilter(name);
        }

        public override IEnumerable<LogSource> GetMatchingTraceSources(LogEntry logEntry)
        {
            return LogWriter.GetMatchingTraceSources(logEntry);
        }

        public override bool IsLoggingEnabled()
        {
            return LogWriter.IsLoggingEnabled();
        }

        public override bool IsTracingEnabled()
        {
            return LogWriter.IsTracingEnabled();
        }

        public override bool ShouldLog(LogEntry log)
        {
            return LogWriter.ShouldLog(log);
        }

        public override void Write(LogEntry log)
        {
            LogWriter.Write(log);
        }

        public override IDictionary<string, LogSource> TraceSources
        {
            get { return LogWriter.TraceSources; }
        }
    }
}
