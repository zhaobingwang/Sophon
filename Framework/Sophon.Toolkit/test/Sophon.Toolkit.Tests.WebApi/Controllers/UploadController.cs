using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sophon.Toolkit.Web.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Tests.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("single-file")]
        public async Task<IActionResult> SingleFile(IFormFile file)
        {
            LocalMachineFileService localMachineFileService = new LocalMachineFileService();
            await localMachineFileService.SaveAsync(file, file.FileName);
            return Ok();
        }

        [HttpPost("single-file-withmd5")]
        public async Task<IActionResult> SingleFileWithMd5(IFormFile file)
        {
            LocalMachineFileService localMachineFileService = new LocalMachineFileService();
            await localMachineFileService.SaveAsync(file, file.FileName);
            return Ok();
        }
    }
}
