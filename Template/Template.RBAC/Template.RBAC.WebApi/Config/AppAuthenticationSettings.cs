using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Config
{
    /// <summary>
    /// 应用认证配置
    /// </summary>
    public class AppAuthenticationSettings
    {
        public string AppId { get; set; }
        public string Secret { get; set; }
    }
}
