using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.RBAC.WebApi.Entities;
using Template.RBAC.WebApi.Enums;

namespace Template.RBAC.WebApi.Data
{
    /// <summary>
    /// 假数据
    /// </summary>
    public static class Faker
    {
        static DateTime now;
        static Guid administratorId;
        static Guid adminId;
        static Guid guestId;
        static Faker()
        {
            now = DateTime.UtcNow;

            administratorId = Guid.NewGuid();
            adminId = Guid.NewGuid();
            guestId = Guid.NewGuid();
        }

        /// <summary>
        /// 获取假用户数据
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SysUser> GetSysUser()
        {
            var users = new List<SysUser>();

            users.Add(new SysUser
            {
                Id = administratorId,
                LoginName = "administrator",
                DisplayName = "超级管理员",
                PasswordHash = "111111".ToMd5(),
                Avatar = string.Empty,
                Type = UserType.SuperAdministrator,
                Status = Status.Normal,
                IsLocked = IsLocked.UnLocked,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserLoginName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                Description = "系统超级管理员"
            });

            users.Add(new SysUser
            {
                Id = adminId,
                LoginName = "admin",
                DisplayName = "管理员",
                PasswordHash = "111111".ToMd5(),
                Avatar = string.Empty,
                Type = UserType.Admin,
                Status = Status.Normal,
                IsLocked = IsLocked.UnLocked,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserLoginName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                Description = "系统管理员"
            });

            users.Add(new SysUser
            {
                Id = guestId,
                LoginName = "guest",
                DisplayName = "普通用户",
                PasswordHash = "111111".ToMd5(),
                Avatar = string.Empty,
                Type = UserType.General,
                Status = Status.Normal,
                IsLocked = IsLocked.UnLocked,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserLoginName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                Description = "系统超级管理员"
            });

            return users;
        }
    }
}
