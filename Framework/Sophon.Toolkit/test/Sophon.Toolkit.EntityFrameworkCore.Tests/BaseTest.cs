using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests
{
    public class BaseTest
    {
        public async Task<TestDbContext> GetTestDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var testDbContext = new TestDbContext(options);
            testDbContext.Users.Add(new User
            {
                Id = 1,
                Name = "dev",
                CreateTime = DateTime.Now,
                IsDeleted = false
            });

            await testDbContext.SaveChangesAsync();
            return testDbContext;
        }
    }
}
