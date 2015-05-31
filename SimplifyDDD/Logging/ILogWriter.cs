using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplifyDDD.Logging
{
    /// <summary>
    /// 日志写入器接口
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logEntry"></param>
        void Write(ILogEntry logEntry);
    }
}
