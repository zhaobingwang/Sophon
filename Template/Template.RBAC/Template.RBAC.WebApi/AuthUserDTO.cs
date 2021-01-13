using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi
{
    /// <summary>
    /// 认证用户对象
    /// </summary>
    public class AuthUserDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string AvatorAddress { get; set; }
    }
}
