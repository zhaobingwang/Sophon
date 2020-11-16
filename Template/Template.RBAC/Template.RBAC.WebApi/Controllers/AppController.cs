using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        [HttpGet("dotnet-version")]
        public IActionResult AppInfo()
        {
            return Ok(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
        }
    }
}
