using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        [HttpGet("now")]
        public IActionResult Now()
        {
            return Ok(DateTime.Now.ToString());
        }
    }
}
