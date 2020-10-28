using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Sophon.Infrastructure.Services;
using Sophon.Web.Models;

namespace Sophon.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogTrace("Trace信息");
            _logger.LogDebug("调试信息");
            _logger.LogInformation("普通信息");
            _logger.LogWarning("警告信息");
            _logger.LogError("错误信息");
            _logger.LogCritical("严重信息");
            return View();
        }
        public IActionResult TriggerError()
        {
            throw new Exception("触发异常了。。。");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
