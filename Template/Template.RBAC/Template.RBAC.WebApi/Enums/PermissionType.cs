using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Enums
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum PermissionType
    {
        /// <summary>
        /// 菜单
        /// </summary>
        Menu = 0,

        /// <summary>
        /// 按钮/操作/功能
        /// </summary>
        Action = 1
    }
}
