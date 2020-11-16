using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Enums
{
    public enum Status
    {
        /// <summary>
        /// 未指定
        /// </summary>
        All = -1,

        /// <summary>
        /// 已禁用
        /// </summary>
        Forbidden = 0,

        /// <summary>
        /// 正常
        /// </summary>
        Normal = 1
    }
}
