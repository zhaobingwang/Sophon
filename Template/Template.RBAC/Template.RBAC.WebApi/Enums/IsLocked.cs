using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Enums
{

    /// <summary>
    /// 是否已被锁定
    /// </summary>
    public enum IsLocked
    {
        /// <summary>
        /// 未锁定
        /// </summary>
        UnLocked = 0,

        /// <summary>
        /// 已锁定
        /// </summary>
        Locked = 1
    }
}
