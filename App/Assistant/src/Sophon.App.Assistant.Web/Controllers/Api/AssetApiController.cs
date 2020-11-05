using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure;
using Sophon.Infrastructure.Data;

namespace Sophon.Web.Controllers.Api
{
    [Route("api/asset")]
    [ApiController]
    public class AssetApiController : ControllerBase
    {
        private readonly ILogger<StatisticsController> _logger;
        private readonly SophonDbContext _dbContext;

        public AssetApiController(ILogger<StatisticsController> logger, SophonDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        [HttpGet("category")]
        public async Task<IActionResult> Category()
        {
            var category = await _dbContext.AssetTypes.Select(x => new { x.Code, x.Name }).ToListAsync();
            return Ok(new { code = "0", data = category });
        }
    }
}
