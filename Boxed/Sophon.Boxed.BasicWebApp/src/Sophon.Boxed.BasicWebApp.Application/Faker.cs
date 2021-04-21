using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.Application
{
    public static class Faker
    {
        public static SysUser GetUser()
        {
            return new SysUser
            {
                Id = Guid.Parse("70828ACC-A9C6-417F-BB66-BB2E61198C20"),
                Name = "faker",
                PasswordHash = "faker".Sha256()
            };
        }
    }
}
