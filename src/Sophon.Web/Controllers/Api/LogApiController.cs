using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sophon.Infrastructure.Services;
using Sophon.Infrastructure.VO;

namespace Sophon.Web.Controllers.Api
{
    [Route("api/log")]
    [ApiController]
    public class LogApiController : ControllerBase
    {
        private readonly LogServices _logServices;

        public LogApiController(LogServices logServices)
        {
            _logServices = logServices;
        }

        [HttpPost("listpage")]
        public async Task<IActionResult> ListPage([FromForm] QueryLogsVO vo)
        {
            var result = await _logServices.ListPageAsync(vo);
            return Ok(result);
        }
    }
}
