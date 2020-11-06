using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Serilog;
using Sophon.Infrastructure.Services;
using Sophon.Toolkit;
using Sophon.Web.Hubs;
using Sophon.Web.Models;

namespace Sophon.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotificationHub> _notificationHubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> notificationHubContext)
        {
            _logger = logger;
            _notificationHubContext = notificationHubContext;
        }

        public IActionResult Index()
        {
            //_logger.LogTrace("Trace信息");
            //_logger.LogDebug("调试信息");
            //_logger.LogInformation("普通信息");
            //_logger.LogWarning("警告信息");
            //_logger.LogError("错误信息");

            //throw new BusinessException("A1001", "业务异常", "细节信息");

            RecurringJob.AddOrUpdate(() => TestRecurringJob($"{DateTime.Now}# 测试周期性后台任务(每分钟执行一次)"), "*/1 * * * *", TimeZoneInfo.Utc);

            RecurringJob.AddOrUpdate(() => TestNotificationHubJob(), "*/1 * * * *", TimeZoneInfo.Utc);

            // 执行达不到预期
            //RecurringJob.AddOrUpdate(() => TestRecurringJob($"{DateTime.Now}# 测试周期性后台任务(每5秒执行一次)"),"*/10 * * * * *", TimeZoneInfo.Utc);


            return View();
        }

        public void TestRecurringJob(string message)
        {
            _logger.LogDebug(message);
        }

        public async Task TestNotificationHubJob()
        {
            string message = $"消息已通知# {DateTime.UtcNow}";
            _logger.LogInformation(message);
            await _notificationHubContext.Clients.All.SendAsync("Notify", message);
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
