using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sophon.Toolkit.File;
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

        [HttpPost("single-file2")]
        public async Task<IActionResult> SingleFile2(IFormFile file)
        {
            LocalMachineFileService localMachineFileService = new LocalMachineFileService();
            var result = await localMachineFileService.SaveAsync(file, @"tmp\upload\", "c:\\");
            return Ok(result);
        }

        [HttpPost("single-file-withmd5")]
        public async Task<IActionResult> SingleFileWithMd5(IFormFile file)
        {
            LocalMachineFileService localMachineFileService = new LocalMachineFileService();
            await localMachineFileService.SaveAsync(file, file.FileName);
            return Ok();
        }

        [HttpPost("multi-file")]
        public async Task<IActionResult> MultiFile(List<IFormFile> files)
        {
            LocalMachineFileService localMachineFileService = new LocalMachineFileService();
            var result = await localMachineFileService.SaveAsync(files, @"tmp\upload\", "c:\\");
            return Ok(result);
        }
    }
}
