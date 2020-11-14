using Microsoft.EntityFrameworkCore;
using Sophon.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Data
{
    public class SophonDbContext : DbContext
    {
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<AssetRecord> AssetRecords { get; set; }

        public SophonDbContext(DbContextOptions<SophonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.ToTable("AssetType");
                entity.HasKey(x => x.Code);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(x => x.Code).HasMaxLength(64).IsRequired();
                entity.Property(x => x.Name).HasMaxLength(64).IsRequired();
                entity.Property(x => x.Method).IsRequired();
            });

            modelBuilder.Entity<AssetRecord>(entity =>
            {
                entity.ToTable("AssetRecord");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id);
                entity.Property(x => x.TypeCode).HasMaxLength(64).IsRequired();
                entity.Property(x => x.TypeName).HasMaxLength(64).IsRequired();
                entity.Property(x => x.AggregateAmount).IsRequired();
                entity.Property(x => x.CreateTime).IsRequired();
                entity.Property(x => x.IsDeleted).IsRequired();
            });
        }
    }
}
