using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Entities
{
    public class SysRolePermissionMapping
    {  /// <summary>
       /// 角色编码
       /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 权限编码
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string PermissionCode { get; set; }

        public DateTime CreateTime { get; set; }


        public SysRole SysRole { get; set; }
        public SysPermission SysPermission { get; set; }
    }
}
