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
                entity.ToTable("asset_type");
                entity.HasKey(x => x.Code);
                entity.HasIndex(x => x.Name).IsUnique();

                entity.Property(x => x.Code).HasColumnName("code").HasMaxLength(12).IsRequired();
                entity.Property(x => x.Name).HasColumnName("name").HasMaxLength(12).IsRequired();
                entity.Property(x => x.Method).HasColumnName("method").IsRequired();
            });

            modelBuilder.Entity<AssetRecord>(entity =>
            {
                entity.ToTable("asset_record");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id).HasColumnName("id");
                entity.Property(x => x.TypeCode).HasColumnName("type_code").HasMaxLength(12).IsRequired();
                entity.Property(x => x.TypeName).HasColumnName("type_name").HasMaxLength(12).IsRequired();
                entity.Property(x => x.AggregateAmount).HasColumnName("aggregate_amount").IsRequired();
                entity.Property(x => x.CreateTime).HasColumnName("create_time").IsRequired();
                entity.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            });
        }
    }
}
