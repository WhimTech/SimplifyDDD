using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using SimplifyDDD.Logging;

namespace SimplifyDDD.EntLibLogging
{
    public class Logger : ILogger
    {
        private readonly LogWriter _writer;

        public Logger(LogWriter writer)
        {
            _writer = writer;
        }

        public void Debug(object message)
        {
            var log = new LogEntry
            {
                Message = message.ToString(),
                Priority = (int)TraceEventType.Verbose,
                Severity = TraceEventType.Verbose
            };
            log.Categories.Add("Debug");
            _writer.Write(log);
        }

        public void DebugFormat(string format, params object[] args)
        {
            Debug(string.Format(format, args));
        }

        public void Debug(object message, Exception exception)
        {
            DebugFormat("Message:{0},Exception:{1},StackTrace:{2}", message.ToString(), exception.Message, exception.StackTrace);
        }

        public void Info(object message)
        {
            var log = new LogEntry
            {
                Message = message.ToString(),
                Priority = (int)TraceEventType.Information,
                Severity = TraceEventType.Information
            };
            log.Categories.Add("Information");
            _writer.Write(log);
        }

        public void InfoFormat(string format, params object[] args)
        {
            Info(string.Format(format, args));
        }

        public void Info(object message, Exception exception)
        {
            InfoFormat("Message:{0},Exception:{1},StackTrace:{2}", message.ToString(), exception.Message, exception.StackTrace);
        }

        public void Error(object message)
        {
            var log = new LogEntry
            {
                Message = message.ToString(),
                Priority = (int)TraceEventType.Error,
                Severity = TraceEventType.Error
            };
            log.Categories.Add("Error");
            _writer.Write(log);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        public void Error(object message, Exception exception)
        {
            ErrorFormat("Message:{0},Exception:{1},StackTrace:{2}", message.ToString(), exception.Message, exception.StackTrace);
        }

        public void Warn(object message)
        {
            var log = new LogEntry
            {
                Message = message.ToString(),
                Priority = (int)TraceEventType.Warning,
                Severity = TraceEventType.Warning
            };
            log.Categories.Add("Warning");
            _writer.Write(log);
        }

        public void WarnFormat(string format, params object[] args)
        {
            Warn(string.Format(format, args));
        }

        public void Warn(object message, Exception exception)
        {
            WarnFormat("Message:{0},Exception:{1},StackTrace:{2}", message.ToString(), exception.Message, exception.StackTrace);
        }

        public void Fatal(object message)
        {
            var log = new LogEntry
            {
                Message = message.ToString(),
                Priority = (int)TraceEventType.Critical,
                Severity = TraceEventType.Critical
            };
            log.Categories.Add("Critical");
            _writer.Write(log);
        }

        public void FatalFormat(string format, params object[] args)
        {
            Fatal(string.Format(format, args));
        }

        public void Fatal(object message, Exception exception)
        {
            FatalFormat("Message:{0},Exception:{1},StackTrace:{2}", message.ToString(), exception.Message, exception.StackTrace);
        }
    }
}
