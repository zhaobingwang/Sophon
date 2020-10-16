using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure.Services;
using Sophon.Web.Models;

namespace Sophon.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AssetServices assetServices;
        public HomeController(ILogger<HomeController> logger, AssetServices assetServices)
        {
            _logger = logger;
            this.assetServices = assetServices;
        }

        public async Task<IActionResult> Index()
        {
            var source = await assetServices.TotalStatistics();
            var aa = string.Join(',', source.Select(x => x.Name));
            ViewData["XAxis"] = string.Join(',', source.Select(x => x.Name));
            ViewData["YAxis"] = string.Join(',', source.Select(x => x.AggregateAmount));
            return View();
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
