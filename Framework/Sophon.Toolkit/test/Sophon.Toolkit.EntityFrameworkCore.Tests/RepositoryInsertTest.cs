using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.EntityFrameworkCore.Tests
{
    public class RepositoryInsertTest : BaseTest
    {
        private UnitOfWork<TestDbContext> unitOfWork;
        private IRepository<User> userRepository;
        private IRepository<Department> deptRepository;
        private IRepository<UserDepartment> userDeptRepository;
        public RepositoryInsertTest()
        {
            var dbContext = GetTestDbContextAsync().Result;
            unitOfWork = new UnitOfWork<TestDbContext>(dbContext);
            userRepository = unitOfWork.GetRepository<User>();
            deptRepository = unitOfWork.GetRepository<Department>();
            userDeptRepository = unitOfWork.GetRepository<UserDepartment>();
        }

        [Fact]
        public void Insert_ReturnEntity_WithCorrectParams()
        {
            var fakerUser = FakerData.GetOneUser();
            var user = userRepository.Insert(fakerUser);
            Assert.NotNull(user);
            Assert.Equal(fakerUser.CreateTime, user.CreateTime);
        }

        [Fact]
        public void Insert_ReturnInsertedCount_WithMultiCorrectParams()
        {
            var fakerUsers = FakerData.GetMultiUser();
            userRepository.Insert(fakerUsers);
            var result = unitOfWork.SaveChangesAsync().Result;
            Assert.True(fakerUsers.Count == result);

            fakerUsers = FakerData.GetMultiUser();
            userRepository.Insert(fakerUsers.ToArray());
            result = unitOfWork.SaveChangesAsync().Result;
            Assert.True(fakerUsers.Count == result);
        }

        [Fact]
        public async Task InsertAsync_ReturnEntity_WhenSuccess()
        {
            var fakerUser = new User
            {
                Name = "insert-one-01",
                IsDeleted = false,
                CreateTime = DateTime.Now,
            };

            var user = await userRepository.InsertAsync(fakerUser);
            await unitOfWork.SaveChangesAsync();
            Assert.True(user != null);
            Assert.True(user.Entity.Name == fakerUser.Name);
        }


        [Fact]
        public async Task InsertAsync_ReturnInsertedCount_WithMultiCorrectParams()
        {
            var fakerUsers = FakerData.GetMultiUser();
            await userRepository.InsertAsync(fakerUsers);
            var result = unitOfWork.SaveChangesAsync().Result;
            Assert.True(fakerUsers.Count == result);

            fakerUsers = FakerData.GetMultiUser();
            await userRepository.InsertAsync(fakerUsers.ToArray());
            result = unitOfWork.SaveChangesAsync().Result;
            Assert.True(fakerUsers.Count == result);
        }

        [Fact]
        public async Task InsertAsync_ThrowDbUpdateException_WhenInsertWithWrongFK()
        {
            var fakerUser = new User
            {
                Name = "test-user-01",
                IsDeleted = false,
                CreateTime = DateTime.Now,
            };
            var fakerDept = new Department
            {
                Name = "test-dept-01",
                Level = 1,
            };

            var fakerUserDept = new UserDepartment
            {
                UserId = fakerUser.Id,
                DepartmentId = fakerDept.Id
            };

            var user = await userRepository.InsertAsync(fakerUser);
            var dept = await deptRepository.InsertAsync(fakerDept);
            var userDept = await userDeptRepository.InsertAsync(fakerUserDept);

            await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => unitOfWork.SaveChangesAsync());
        }

        [Fact]
        public async Task InsertAsync_ReturnExpectedResult_WhenInsertWithCorrectData()
        {
            var fakerUser = new User
            {
                Name = "test-user-01",
                IsDeleted = false,
                CreateTime = DateTime.Now,
            };
            var fakerDept = new Department
            {
                Name = "test-dept-01",
                Level = 1,
            };

            var fakerUserDept = new UserDepartment
            {
                User = fakerUser,
                Department = fakerDept
            };

            var user = await userRepository.InsertAsync(fakerUser);
            var dept = await deptRepository.InsertAsync(fakerDept);
            var userDept = await userDeptRepository.InsertAsync(fakerUserDept);

            var result = await unitOfWork.SaveChangesAsync();
            Assert.True(result == 3);
        }

    }
}
