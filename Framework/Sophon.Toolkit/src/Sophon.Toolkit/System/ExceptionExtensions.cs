using Microsoft.Extensions.Logging;
using Sophon.Toolkit.Logging;
using System;

namespace System
{
    /// <summary>
    /// <see cref="Exception"/>扩展方法
    /// </summary>
    public static class ExceptionExtensions
    {
        public static LogLevel GetLogLevel(this Exception exception, LogLevel defaultLogLevel = LogLevel.Error)
        {
            return (exception as IHasLogLevel)?.LogLevel ?? defaultLogLevel;
        }
    }
}
