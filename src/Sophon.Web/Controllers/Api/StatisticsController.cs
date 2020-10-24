using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure;
using Sophon.Infrastructure.Data;
using Sophon.Infrastructure.Services;

namespace Sophon.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly SophonDbContext _dbContext;

        public StatisticsController(ILogger<StatisticsController> logger, SophonDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("total")]
        public async Task<IActionResult> Total()
        {
            List<string> types = new List<string>();
            List<KV> latestAmount = new List<KV>();
            var assetTypes = await _dbContext.AssetTypes.ToListAsync();
            foreach (var assetType in assetTypes)
            {
                var currentAsset = await _dbContext.AssetRecords
                    .Where(x => x.IsDeleted == IsDeleted.No)
                    .OrderByDescending(x => x.CreateTime)
                    .FirstOrDefaultAsync(x => x.TypeCode == assetType.Code);

                types.Add(assetType.Name);
                latestAmount.Add(new KV { Name = assetType.Name, Value = currentAsset?.AggregateAmount ?? 0M });
            }
            return Ok(new { legend = types, series = latestAmount });
        }

        // TODO: 优化
        [HttpGet("ar")]
        public async Task<IActionResult> AssetRecords()
        {
            var assetTypes = await _dbContext.AssetTypes.ToListAsync();
            var ar = await _dbContext.AssetRecords.ToListAsync();
            List<Series> series = new List<Series>();
            IEnumerable<string> x = new List<string>();
            foreach (var item in assetTypes)
            {
                if (ar.Exists(x => x.TypeName == item.Name))
                {
                    series.Add(new Series
                    {
                        Smooth = true,
                        Name = item.Name,
                        Type = "line",
                        //Stack = "平均金额",
                        Data = ar.Where(x => x.TypeName == item.Name).GroupBy(x => x.CreateTime.ToString("yyyy-MM-dd")).Select(x => x.Average(y => y.AggregateAmount))
                    });
                    if (x.Count() < 1)
                    {
                        x = ar.Select(x => x.CreateTime.ToString("yyyy-MM-dd")).Distinct();
                    }
                }

            }

            var result = new ChartOption
            {
                Title = new Title { Text = "测试" },
                Legend = new Legend { Data = assetTypes.Select(x => x.Name) },
                Series = series,
                XAxis = new XAxis
                {
                    Type = "category",
                    BoundaryGap = "false",
                    Data = x,
                }
            };
            return Ok(result);
        }
    }

    public class KV
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
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
        public bool Smooth { get; set; }
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
