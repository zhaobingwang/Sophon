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
        protected DbContextOptions<TestDbContext> ContextOptions { get; }
        public BaseTest()
        {
            ContextOptions = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlite(@"Filename = Sophon.Toolkit.EntityFrameworkCore.UnitTest.db")
                .Options;

            Seed();
        }
        public async Task<TestDbContext> GetTestDbContextAsync()
        {
            await Task.CompletedTask;

            var testDbContext = new TestDbContext(ContextOptions);

            return testDbContext;
        }


        private void Seed()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var users = new List<User>() {
                    new User
                    {
                        Name = "init-01",
                        CreateTime = DateTime.Now,
                        IsDeleted = false
                    }
                };

                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
