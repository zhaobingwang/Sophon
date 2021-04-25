using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests
{
    public static class FakerData
    {
        public static User GetOneUser()
        {
            return new User
            {
                Name = "faker-user",
                IsDeleted = false,
                CreateTime = DateTime.Now,
            };
        }

        public static List<User> GetMultiUser(int count = 3)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < count; i++)
            {
                users.Add(new User
                {
                    Name = $"faker-user-{i}",
                    IsDeleted = false,
                    CreateTime = DateTime.Now,
                });
            }
            return users;
        }
    }
}
