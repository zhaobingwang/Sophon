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
    public class SysUser //: BaseEntity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DefaultValue("newid()")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)", Order = 2)]
        public string LoginName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)", Order = 3)]
        public string DisplayName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)", Order = 4)]
        public string PasswordHash { get; set; }

        [Column(TypeName = "nvarchar(255)", Order = 100)]
        public string Avatar { get; set; }

        public UserType Type { get; set; }

        public Status Status { get; set; }

        public IsLocked IsLocked { get; set; }

        public IsDeleted IsDeleted { get; set; }


        public DateTime CreateTime { get; set; }
        public Guid CreateUserId { get; set; }
        public string CreateUserLoginName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string UpdateUserLoginName { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        /// <summary>
        /// 用户的角色集合
        /// </summary>
        public ICollection<SysUserRoleMapping> SysUserRoles { get; set; }
    }
}
