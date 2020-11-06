using Microsoft.Extensions.Logging;
using Sophon.Toolkit.ExceptionHanding;
using Sophon.Toolkit.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Toolkit
{
    public class BusinessException : Exception,
        IBusinessException,
        IHasErrorCode,
        IHasErrorDetails,
        IHasLogLevel
    {
        public string Code { get; set; }

        public string Details { get; set; }

        public LogLevel LogLevel { get; set; }

        public BusinessException(
            string code = null,
            string message = null,
            string details = null,
            Exception innerException = null,
            LogLevel logLevel = LogLevel.Warning)
            : base(message, innerException)
        {
            Code = code;
            Details = details;
            LogLevel = logLevel;
        }
    }
}
