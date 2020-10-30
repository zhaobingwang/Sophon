using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Web.Filter
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider,
            ILogger<CustomExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            //if (!_hostingEnvironment.IsDevelopment())
            //{
            //    return;
            //}
            _logger.LogError(context.Exception.Message, context.Exception);

            //var result = new ViewResult { ViewName = "Error" };
            //result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
            //                                            context.ModelState);
            //result.ViewData.Add("Exception", context.Exception);
            // TODO: Pass additional detailed data via ViewData
            //context.Result = result;
        }
    }
}
