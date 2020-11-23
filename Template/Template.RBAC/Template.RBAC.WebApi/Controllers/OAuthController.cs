using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Config;
using Template.RBAC.WebApi.Data;
using Template.RBAC.WebApi.Entities;
using Template.RBAC.WebApi.Enums;
using Template.RBAC.WebApi.Extensions;

namespace Template.RBAC.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly AppAuthenticationSettings _appAuthenticationSettings;
        private readonly TemplateDbContext _dbContext;

        public OAuthController(IOptions<AppAuthenticationSettings> appAuthenticationSettings, TemplateDbContext dbContext)
        {
            _appAuthenticationSettings = appAuthenticationSettings.Value;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Authentication(string userName, string password)
        {
            var response = ResponseVOFactory.CreateInstanse;
            SysUser user;

            using (_dbContext)
            {
                user = _dbContext.SysUser.FirstOrDefault(x => x.LoginName == userName.Trim());
                if (user == null || user.IsDeleted == IsDeleted.Yes)
                {
                    response.SetFailed("用户不存在");
                    return Ok(response);
                }
                // FIX: http先明文传输
                if (user.PasswordHash != password.Trim()?.ToMd5())
                {
                    response.SetFailed("用户密码错误");
                    return Ok(response);
                }
                if (user.IsLocked == IsLocked.Locked)
                {
                    response.SetFailed("用户已被锁定");
                    return Ok(response);
                }
                if (user.Status == Status.Forbidden)
                {
                    response.SetFailed("用户账号已被禁用");
                    return Ok(response);
                }
            }

            var claimsIdentity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,userName),
                new Claim("guid",user.Id.ToString()),
                new Claim("avatar",""),
                new Claim("displayName",user.DisplayName),
                new Claim("loginName",user.LoginName),
                new Claim("emailAddress",""),
                new Claim("guid",user.Id.ToString()),
                new Claim("userType",((int)user.Type).ToString())
            });

            var token = JwtBearerAuthenticationExtension.GetJwtAccessToken(_appAuthenticationSettings, claimsIdentity);
            return Ok(token);
        }
    }
}
