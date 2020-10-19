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
        private readonly ILogger<StatisticsController> _logger;
        private readonly AssetServices _assetServices;
        private readonly AssetRecordServices _assetRecordServices;

        public StatisticsController(ILogger<StatisticsController> logger, AssetServices assetServices, AssetRecordServices assetRecordServices)
        {
            _logger = logger;
            _assetServices = assetServices;
            _assetRecordServices = assetRecordServices;
        }

        [HttpGet("total")]
        public async Task<IActionResult> Total()
        {
            var source = await _assetServices.TotalStatistics();
            return Ok(new { x = source.Select(x => x.Name), y = source.Select(x => x.AggregateAmount) });
        }

        // TODO: 优化
        [HttpGet("ar")]
        public async Task<IActionResult> AssetRecords()
        {
            var source = await _assetServices.TotalStatistics();
            var ar = await _assetRecordServices.ListAllAsync();
            List<Series> series = new List<Series>();
            IEnumerable<string> x = new List<string>();
            foreach (var item in source)
            {
                if (ar.Exists(x => x.AssetName == item.Name))
                {
                    series.Add(new Series
                    {
                        Name = item.Name,
                        Type = "line",
                        Stack = "平均金额",
                        Data = ar.Where(x => x.AssetName == item.Name).GroupBy(x => x.CreateTime.ToString("yyyy-MM-dd")).Select(x => x.Average(y => y.AggregateAmount))
                    });
                    if (x.Count() < 1)
                    {
                        x = ar.Select(x => x.CreateTime.ToString("yyyy-MM-dd")).Distinct();
                    }
                }

            }

            return Ok(new ChartOption
            {
                Title = new Title { Text = "测试" },
                Legend = new Legend { Data = source.Select(x => x.Name) },
                Series = series,
                XAxis = new XAxis
                {
                    Type = "category",
                    BoundaryGap = "false",
                    Data = x,
                }
            });
        }
    }

    public class ChartOption
    {
        public Title Title { get; set; }
        public Legend Legend { get; set; }
        public List<Series> Series { get; set; }
        public XAxis XAxis { get; set; }
    }
    public class Title
    {
        public string Text { get; set; }
    }
    public class Legend
    {
        public IEnumerable<string> Data { get; set; }
    }


    public class Series
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Stack { get; set; }
        public IEnumerable<decimal> Data { get; set; }
    }

    public class XAxis
    {
        public string Type { get; set; }
        public string BoundaryGap { get; set; }
        public IEnumerable<string> Data { get; set; }
    }
}
