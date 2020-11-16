using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Config;

namespace Template.RBAC.WebApi.Extensions
{
    /// <summary>
    /// JWT认证扩展
    /// </summary>
    public class JwtBearerAuthenticationExtension
    {
        /// <summary>
        /// 获取Jwt AccessToken
        /// </summary>
        /// <param name="appAuthenticationSettings"></param>
        /// <param name="claimsIdentity"></param>
        /// <returns></returns>
        public static string GetJwtAccessToken(AppAuthenticationSettings appAuthenticationSettings, ClaimsIdentity claimsIdentity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appAuthenticationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
