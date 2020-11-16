using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi.Entities
{
    public class SysPermission
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        [Required]
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        /// <summary>
        /// 菜单GUID
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        /// <summary>
        /// 权限操作码
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ActionCode { get; set; }
        public string Icon { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public Status Status { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public PermissionType Type { get; set; }

        public Guid CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUserId { get; set; }
        /// <summary>
        /// 最近修改者姓名
        /// </summary>
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 关联的菜单
        /// </summary>
        public SysMenu SysMenu { get; set; }

        /// <summary>
        /// 权限所属的角色集合
        /// </summary>
        public ICollection<SysRolePermissionMapping> SysRoles { get; set; }
    }
}
