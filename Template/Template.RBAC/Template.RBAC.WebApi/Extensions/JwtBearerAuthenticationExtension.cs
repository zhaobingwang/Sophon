using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
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
    public static class JwtBearerAuthenticationExtension
    {
        public static void AddJwtBearerAuthentication(this IServiceCollection services, AppAuthenticationSettings appSettings)
        {
            //使用应用密钥得到一个加密密钥字节数组
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(cfg => cfg.SlidingExpiration = true)
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

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
