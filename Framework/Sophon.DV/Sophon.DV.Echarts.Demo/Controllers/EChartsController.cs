using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sophon.DV.Echarts.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EChartsController : ControllerBase
    {
        [HttpGet("products")]
        public ActionResult Products()
        {
            var data = FakeData.ProductData();
            return Ok(data);
        }
    }
}
