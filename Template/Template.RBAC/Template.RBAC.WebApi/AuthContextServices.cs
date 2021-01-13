using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi
{
    /// <summary>
    /// 认证上下文服务
    /// </summary>
    public static class AuthContextServices
    {
        private static IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 配置认证上下文
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public static void Configure(HttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 当前HTTP上下文
        /// </summary>
        public static HttpContext Current
        {
            get
            {
                return _httpContextAccessor.HttpContext;
            }
        }

        /// <summary>
        /// 当前认证用户信息
        /// </summary>
        public static AuthUserDTO CurrentUser
        {
            get
            {
                var user = new AuthUserDTO
                {
                    LoginName = Current.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    DisplayName = Current.User.FindFirstValue(Const.ClaimTypes.DisplayName),
                    Email = Current.User.FindFirstValue(Const.ClaimTypes.Email),
                    UserType = (UserType)Convert.ToInt32(Current.User.FindFirstValue(Const.ClaimTypes.UserType)),
                    AvatorAddress = Current.User.FindFirstValue(Const.ClaimTypes.AvatorAddress),
                    Id = new Guid(Current.User.FindFirstValue(Const.ClaimTypes.Id))
                };
                return user;
            }
        }

        /// <summary>
        /// 是否已认证
        /// </summary>
        public static bool IsAuthenticated
        {
            get
            {
                return Current.User.Identity.IsAuthenticated;
            }
        }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public static bool IsSuperAdministrator
        {
            get
            {
                return (UserType)Convert.ToInt32(Current.User.FindFirstValue("user-type")) == UserType.SuperAdministrator;
            }
        }
    }
}
