using Microsoft.EntityFrameworkCore;
using Sophon.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Data
{
    public class SophonDbContext : DbContext
    {
        public DbSet<Tmp> Tmp { get; set; }

        public SophonDbContext(DbContextOptions<SophonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tmp>().ToTable("tmp");
        }
    }
}
