using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiInfosController : ControllerBase
    {
        private readonly IOptions<ApiInfos> _apiInfos;

        public ApiInfosController(IOptions<ApiInfos> apiInfos)
        {
            _apiInfos = apiInfos;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_apiInfos.Value);
        }
    }
}
