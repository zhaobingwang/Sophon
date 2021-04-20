using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        public AccountController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("login")]
        public async Task<SysUser> LoginAsync(string name, string password)
        {
            await Task.CompletedTask;
            if (User.Name == name && User.PasswordHash == password.Sha256())
            {
                return User;
            }
            return null;
        }

        [HttpPost("token")]
        public string GetToken(SysUser user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("id",user.Id.ToString(),ClaimValueTypes.String),
                new Claim("name",user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecurityKey)), SecurityAlgorithms.HmacSha256),
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(_jwtSettings.ExpireSeconds)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }

        private readonly static SysUser User = new SysUser
        {
            Id = Guid.Parse("70828ACC-A9C6-417F-BB66-BB2E61198C20"),
            Name = "dev",
            PasswordHash = "123456".Sha256()
        };

    }
}
