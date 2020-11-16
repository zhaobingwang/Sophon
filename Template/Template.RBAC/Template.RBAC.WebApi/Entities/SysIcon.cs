using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi.Entities
{
    public class SysIcon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 图标名称
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        /// <summary>
        /// 图标的大小，单位是 px
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string Size { get; set; }

        /// <summary>
        /// 图标颜色
        /// </summary>
        [Column(TypeName = "nvarchar(20)")]
        public string Color { get; set; }

        /// <summary>
        /// 自定义图标
        /// </summary>
        [Column(TypeName = "nvarchar(50)")]
        public string Custom { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public Status Status { get; set; }

        public IsDeleted IsDeleted { get; set; }


        public DateTime CreateTime { get; set; }
        public Guid CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime? UpdateTime { get; set; }
        public Guid? UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
    }
}
