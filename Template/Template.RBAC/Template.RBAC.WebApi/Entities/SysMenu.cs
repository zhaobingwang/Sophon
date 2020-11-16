using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi.Entities
{
    public class SysMenu
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DefaultValue("newid()")]
        public Guid Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required, Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Url { get; set; }

        /// <summary>
        /// 页面别名
        /// </summary>
        [Column(TypeName = "nvarchar(255)")]
        public string Alias { get; set; }

        /// <summary>
        /// 菜单图标(可选)
        /// </summary>
        [Column(TypeName = "nvarchar(128)")]
        public string Icon { get; set; }

        /// <summary>
        /// 父级GUID
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 上级菜单名称
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 菜单层级深度
        /// </summary>
        public int Level { get; set; }
        [Column(TypeName = "nvarchar(800)")]
        public string Description { get; set; }
        public int Sort { get; set; }
        public Status Status { get; set; }
        public IsDeleted IsDeleted { get; set; }
        /// <summary>
        /// 是否为默认路由
        /// </summary>
        public YesOrNo IsDefaultRouter { get; set; }

        public DateTime CreateTime { get; set; }
        public Guid CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 前端组件(.vue)
        /// </summary>
        [StringLength(255)]
        public string Component { get; set; }

        /// <summary>
        /// 在菜单中隐藏
        /// </summary>
        public YesOrNo? HideInMenu { get; set; }

        /// <summary>
        /// 不缓存页面
        /// </summary>
        public YesOrNo? NotCache { get; set; }

        /// <summary>
        /// 页面关闭前的回调函数
        /// </summary>
        [StringLength(255)]
        public string BeforeCloseFun { get; set; }

        /// <summary>
        /// 菜单拥有的权限列表
        /// </summary>
        public ICollection<SysPermission> SysPermissions { get; set; }
    }
}
