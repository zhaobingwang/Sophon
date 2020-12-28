using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var repository = _unitOfWork.GetRepository<User>();
                await repository.InsertAsync(new User
                {
                    Name = "A01",
                    IsDeleted = false,
                    CreateTime = DateTime.Now
                });

                //int a = 0;
                //int b = 10 / a;
                await repository.InsertAsync(new User
                {
                    Name = "A01",
                    IsDeleted = false,
                    CreateTime = DateTime.Now
                });

                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
