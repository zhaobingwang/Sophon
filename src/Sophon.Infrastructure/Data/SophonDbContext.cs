using Microsoft.EntityFrameworkCore;
using Sophon.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Data
{
    public class SophonDbContext : DbContext
    {
        public DbSet<Asset> Assets { get; set; }

        public SophonDbContext(DbContextOptions<SophonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("assets");
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(x => x.Name).IsRequired();
            });
        }
    }
}
