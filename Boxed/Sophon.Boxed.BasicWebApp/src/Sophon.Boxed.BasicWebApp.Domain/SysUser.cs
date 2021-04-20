using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp
{
    // TODO: 按字段类型抽象出来，比如审计模型，是否有创建时间等接口（抽象到Sophon.Boxed.Domain...）
    public class SysUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }

        public Guid CreatorId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastModificationTime { get; set; }
        public Guid LastModifierId { get; set; }

        public bool IsDeleted { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
