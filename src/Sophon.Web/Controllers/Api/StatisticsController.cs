using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure.Services;

namespace Sophon.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> logger;
        private readonly AssetServices assetServices;
        public StatisticsController(ILogger<StatisticsController> logger, AssetServices assetServices)
        {
            this.logger = logger;
            this.assetServices = assetServices;
        }

        [HttpGet("total")]
        public async Task<IActionResult> Total()
        {
            var source = await assetServices.TotalStatistics();
            return Ok(new { x = source.Select(x => x.Name), y = source.Select(x => x.AggregateAmount) });
        }
    }
}
