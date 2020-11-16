using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.Entities
{
    public class TemplateDbContext : DbContext
    {
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<SysRole> SysRole { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<SysMenu> SysMenu { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public DbSet<SysIcon> SysIcon { get; set; }

        /// <summary>
        /// 用户-角色多对多映射
        /// </summary>
        public DbSet<SysUserRoleMapping> SysUserRoleMapping { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public DbSet<SysPermission> SysPermission { get; set; }
        /// <summary>
        /// 角色-权限多对多映射
        /// </summary>
        public DbSet<SysRolePermissionMapping> SysRolePermissionMapping { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasIndex(x => x.Code).IsUnique();
            });

            modelBuilder.Entity<SysMenu>(entity =>
            {

            });

            modelBuilder.Entity<SysUserRoleMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.UserId,
                    x.RoleCode
                });

                entity.HasOne(x => x.SysUser)
                    .WithMany(x => x.SysUserRoles)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SysRole)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<SysPermission>(entity =>
            {
                entity.HasIndex(x => x.Code)
                    .IsUnique();

                entity.HasOne(x => x.SysMenu)
                    .WithMany(x => x.SysPermissions)
                    .HasForeignKey(x => x.MenuId);
            });

            modelBuilder.Entity<SysRolePermissionMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.RoleCode,
                    x.PermissionCode
                });

                entity.HasOne(x => x.SysRole)
                    .WithMany(x => x.Permissions)
                    .HasForeignKey(x => x.RoleCode)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.SysPermission)
                    .WithMany(x => x.SysRoles)
                    .HasForeignKey(x => x.PermissionCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
