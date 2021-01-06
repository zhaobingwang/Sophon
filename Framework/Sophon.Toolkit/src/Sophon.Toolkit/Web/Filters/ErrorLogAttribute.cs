using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Web.Filters
{
    public class ErrorLogAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ErrorLogAttribute> _logger;

        public ErrorLogAttribute(ILogger<ErrorLogAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                return;
            }
            _logger.LogError(context.Exception, context.Exception.Message);
        }
    }
}