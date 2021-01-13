using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Const
{
    /// <summary>
    /// 对<see cref="System.Security.Claims.ClaimTypes"/>的补充
    /// </summary>
    public static class ClaimTypes
    {
        /// <summary>
        /// ID
        /// </summary>
        public const string Id = "id";

        /// <summary>
        /// 显示名称
        /// </summary>
        public const string DisplayName = "display-name";

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public const string Email = "email";

        /// <summary>
        /// 用户类型<see cref="Enums.UserType"/>
        /// </summary>
        public const string UserType = "user-type";

        /// <summary>
        /// 头像地址
        /// </summary>
        public const string AvatorAddress = "avator_address";
    }
}
