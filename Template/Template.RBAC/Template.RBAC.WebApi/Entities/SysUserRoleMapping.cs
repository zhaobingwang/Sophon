using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Entities
{
    public class SysUserRoleMapping
    {       
        public Guid UserId { get; set; }
        public string RoleCode { get; set; }

        public SysUser SysUser { get; set; }
        public SysRole SysRole { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
