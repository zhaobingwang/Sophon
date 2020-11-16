using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi.Entities
{
    public class SysRole
    {
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public Status Status { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }
        public Guid CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string UpdateUserLoginName { get; set; }

        /// <summary>
        /// 是否是超级管理员(超级管理员拥有系统的所有权限)
        /// </summary>
        public bool IsSuperAdministrator { get; set; }

        /// <summary>
        /// 是否是系统内置角色(系统内置角色不允许删除,修改操作)
        /// </summary>
        public bool IsBuiltin { get; set; }


        /// <summary>
        /// 角色拥有的用户集合
        /// </summary>
        public ICollection<SysUserRoleMapping> UserRoles { get; set; }

        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public ICollection<SysRolePermissionMapping> Permissions { get; set; }
    }
}
