using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sophon.Boxed.BasicWebApp.Application;
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
    public class IdentityController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public IdentityController(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("token")]
        public async Task<IActionResult> Token(string name, string password)
        {
            await Task.CompletedTask;

            // TODO: use real user.
            var user = Faker.GetUser();
            if (user.Name != name || user.PasswordHash != password.Sha256())
            {
                return NoContent();
            }

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
            //return Ok(jwtToken);
            return Ok(new GetAccessTokenResponse { AccessToken = jwtToken, ExpiresIn = _jwtSettings.ExpireSeconds });
        }
    }
}
