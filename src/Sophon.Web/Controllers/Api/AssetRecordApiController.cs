using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure;
using Sophon.Infrastructure.Data;
using Sophon.Infrastructure.Entities;
using Sophon.Infrastructure.Services;

namespace Sophon.Web.Controllers.Api
{
    [Route("api/ar")]
    [ApiController]
    public class AssetRecordApiController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly SophonDbContext _dbContext;

        public AssetRecordApiController(ILogger<StatisticsController> logger, SophonDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] decimal amount, [FromForm] string typeCode, [FromForm] string typeName)
        {
            _dbContext.AssetRecords.Add(new AssetRecord
            {
                AggregateAmount = amount,
                TypeCode = typeCode,
                TypeName = typeName,
                CreateTime = DateTime.UtcNow,
                IsDeleted = IsDeleted.No
            });
            await _dbContext.SaveChangesAsync();
            return Ok(new { code = "0" });
        }
    }
}
