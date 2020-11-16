using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Enums
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {

        /// <summary>
        /// 一般用户
        /// </summary>
        General = 0,

        /// <summary>
        /// 管理员
        /// </summary>
        Admin = 1,

        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdministrator = 2,
    }
}
