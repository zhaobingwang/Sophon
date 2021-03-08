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
    public class Faker
    {
        private DateTime now;

        #region builtin-user-info
        private Guid User_Administrator_Guid = Guid.NewGuid();
        private string User_Administrator_LoginName = "administrator";
        private string User_Administrator_DisplayName = "超级管理员";

        private Guid User_Admin_Guid = Guid.NewGuid();
        private string User_Admin_LoginName = "admin";
        private string User_Admin_DisplayName = "管理员";

        private Guid User_Guest_Guid = Guid.NewGuid();
        private string User_Guest_LoginName = "guest";
        private string User_Guest_DisplayName = "普通用户";

        private string defaultPwdHash = "111111".ToMd5();
        #endregion

        #region builtin-role-info
        private string Role_Administrator_Code = "sys.default.administrator";
        private string Role_Administrator_Name = "超级管理员";

        private string Role_Admin_Code = "sys.default.admin";
        private string Role_Admin_Name = "管理员";

        private string Role_Guest_Code = "sys.default.guest";
        private string Role_Guest_Name = "普通用户";
        #endregion
        public Faker()
        {
            //now = DateTime.UtcNow;
            now = DateTime.Now;
        }

        /// <summary>
        /// 获取假用户数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysUser> GetSysUsers()
        {
            var users = new List<SysUser>();

            users.Add(new SysUser
            {
                Id = User_Administrator_Guid,
                LoginName = User_Administrator_LoginName,
                DisplayName = User_Administrator_DisplayName,
                PasswordHash = defaultPwdHash,
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
                Id = User_Admin_Guid,
                LoginName = User_Admin_LoginName,
                DisplayName = User_Admin_DisplayName,
                PasswordHash = defaultPwdHash,
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
                Id = User_Guest_Guid,
                LoginName = User_Guest_LoginName,
                DisplayName = User_Guest_DisplayName,
                PasswordHash = defaultPwdHash,
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

        public IEnumerable<SysRole> GetSysRoles()
        {
            var roles = new List<SysRole>();

            roles.Add(new SysRole
            {
                Code = Role_Administrator_Code,
                Name = Role_Administrator_Name,
                Description = Role_Administrator_Name,
                Status = Status.Normal,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                IsSuperAdministrator = true,
                IsBuiltin = true,
            });

            roles.Add(new SysRole
            {
                Code = Role_Admin_Code,
                Name = Role_Admin_Name,
                Description = Role_Admin_Name,
                Status = Status.Normal,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                IsSuperAdministrator = true,
                IsBuiltin = true,
            });

            roles.Add(new SysRole
            {
                Code = Role_Guest_Code,
                Name = Role_Guest_Name,
                Description = Role_Guest_Name,
                Status = Status.Normal,
                IsDeleted = IsDeleted.No,
                CreateTime = now,
                CreateUserId = Guid.Empty,
                CreateUserName = string.Empty,
                UpdateTime = now,
                UpdateUserId = Guid.Empty,
                UpdateUserLoginName = string.Empty,
                IsSuperAdministrator = true,
                IsBuiltin = true,
            });

            return roles;
        }

        private IEnumerable<SysUserRoleMapping> GetSysUserRoleMappings()
        {
            var urms = new List<SysUserRoleMapping>();

            urms.Add(new SysUserRoleMapping
            {
                UserId = User_Administrator_Guid,
                RoleCode = Role_Administrator_Code,
                CreateTime = now
            });

            urms.Add(new SysUserRoleMapping
            {
                UserId = User_Admin_Guid,
                RoleCode = Role_Admin_Code,
                CreateTime = now
            });

            urms.Add(new SysUserRoleMapping
            {
                UserId = User_Guest_Guid,
                RoleCode = Role_Guest_Code,
                CreateTime = now
            });

            return urms;
        }
    }
}
