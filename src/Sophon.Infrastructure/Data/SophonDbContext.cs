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
        public DbSet<AssetRecord> AssetRecords { get; set; }

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

            modelBuilder.Entity<AssetRecord>(entity =>
            {
                entity.ToTable("asset_records");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.AggregateAmount).IsRequired();
                entity.Property(x => x.AssetId).IsRequired();
                entity.Property(x => x.AssetName).IsRequired();
            });
        }
    }
}
