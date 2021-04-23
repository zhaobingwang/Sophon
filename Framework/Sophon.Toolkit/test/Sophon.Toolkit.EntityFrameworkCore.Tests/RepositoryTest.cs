using System;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests
{
    public class CRUDUnitTest : BaseTest
    {
        [Fact]
        public async Task Get_User_WithExpectedParameters()
        {
            var dbContext = await GetTestDbContextAsync();
            var iUnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            var repository = iUnitOfWork.GetRepository<User>();
            var user = await repository.FindAsync(1);
            Assert.True(user != null);
        }

        [Fact]
        public async Task FindAsync_ReturnNull_WhenNotExists()
        {
            var dbContext = await GetTestDbContextAsync();
            var iUnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            var repository = iUnitOfWork.GetRepository<User>();
            var user = await repository.FindAsync(999999);
            Assert.True(user == null);
        }

        [Fact]
        public async Task InsertAsync_ReturnEntity_WhenSuccess()
        {
            var fakerUser = new User
            {
                Name = "TEST00001",
                IsDeleted = false,
                CreateTime = DateTime.Now
            };
            var dbContext = await GetTestDbContextAsync();
            var iUnitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            var repository = iUnitOfWork.GetRepository<User>();

            var user = await repository.InsertAsync(fakerUser);

            Assert.True(user != null);
            Assert.True(user.Entity.Name == fakerUser.Name);
        }
    }
}
