using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sophon.Toolkit.IdentityCenter.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Toolkit.IdentityCenter.Infrastructure.Data
{
    public class IdentityCenterDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityCenterDbContext(DbContextOptions<IdentityCenterDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("sys_user");
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("sys_user_claim");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("sys_user_login");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("sys_user_token");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("sys_role");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("sys_role_claim");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("sys_user_role");
            });
        }
    }
}