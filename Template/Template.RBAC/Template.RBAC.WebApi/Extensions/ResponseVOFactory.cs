using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.VO;

namespace Template.RBAC.WebApi.Extensions
{
    /// <summary>
    /// 响应视图对象工厂
    /// </summary>
    public class ResponseVOFactory
    {
        /// <summary>
        /// 创建一个<see cref="ResponseVO"/>实例
        /// </summary>
        /// <returns></returns>
        public static ResponseVO CreateInstanse => new ResponseVO();
    }
}
