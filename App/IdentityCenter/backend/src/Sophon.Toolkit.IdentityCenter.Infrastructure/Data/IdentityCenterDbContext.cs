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
        }
    }
}