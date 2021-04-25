using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests
{
    public class RepositoryFindTest : BaseTest
    {
        private UnitOfWork<TestDbContext> UnitOfWork;
        public RepositoryFindTest()
        {
            var dbContext = GetTestDbContextAsync().Result;
            UnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
        }

        [Fact]
        public async Task FindAsync_ReturnEntity_WhenExists()
        {
            //var dbContext = await GetTestDbContextAsync();
            //var iUnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            var repository = UnitOfWork.GetRepository<User>();
            var user = await repository.FindAsync(1);
            Assert.True(user != null);
        }

        [Fact]
        public async Task FindAsync_ReturnNull_WhenNotExists()
        {
            //var dbContext = await GetTestDbContextAsync();
            //var iUnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            var repository = UnitOfWork.GetRepository<User>();
            var user = await repository.FindAsync(999999);
            Assert.True(user == null);
        }
    }
}
