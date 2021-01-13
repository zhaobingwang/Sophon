using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Data;

namespace Template.RBAC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TemplateDbContext _dbContext;

        public AccountController(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
