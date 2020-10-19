using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sophon.Infrastructure.Entities;

namespace Sophon.Infrastructure.Data
{
    public class SeedData
    {
        const int ASSETS_ID1 = 1;
        const int ASSETS_ID2 = 2;
        const int ASSETS_ID3 = 3;
        const int ASSETS_ID4 = 4;
        const int ASSETS_RECORD_ID1 = 1;
        const int ASSETS_RECORD_ID2 = 2;
        const int ASSETS_RECORD_ID3 = 3;
        const int ASSETS_RECORD_ID4 = 4;
        const int ASSETS_RECORD_ID5 = 5;
        public static async Task SeedAsync(IServiceProvider provider)
        {
            var now = DateTime.UtcNow;
            var dbContext = provider.GetService<SophonDbContext>();
            if (!dbContext.Assets.Any())
            {
                dbContext.Assets.AddRange(GetAssets());
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.AssetRecords.Any())
            {
                dbContext.AssetRecords.AddRange(GetAssetRecords());
                await dbContext.SaveChangesAsync();
            }
        }

        #region FakeData & Default Data
        private static List<Asset> GetAssets()
        {
            var now = DateTime.UtcNow;
            return new List<Asset> {
                new Asset{
                    Id=ASSETS_ID1,
                    Name="个人资产",
                    AggregateAmount=10M,
                    IsDeleted=IsDeleted.No,
                    CreateTime=now,
                    ModifyTime=now,
                },
                new Asset{
                    Id=ASSETS_ID2,
                    Name="父母的养老金",
                    AggregateAmount=20M,
                    IsDeleted=IsDeleted.No,
                    CreateTime=now,
                    ModifyTime=now,
                },
                new Asset{
                    Id=ASSETS_ID3,
                    Name="公积金账户",
                    AggregateAmount=5M,
                    IsDeleted=IsDeleted.No,
                    CreateTime=now,
                    ModifyTime=now,
                },
                new Asset{
                    Id=ASSETS_ID4,
                    Name="测试资产",
                    AggregateAmount=100M,
                    IsDeleted=IsDeleted.No,
                    CreateTime=now,
                    ModifyTime=now,
                },
            };
        }

        private static List<AssetRecord> GetAssetRecords()
        {
            var now = DateTime.UtcNow;
            var assets = GetAssets();
            return new List<AssetRecord> {
                new AssetRecord{
                    Id=ASSETS_RECORD_ID1,
                    AssetId=ASSETS_ID4,
                    AssetName="测试资产",
                    AggregateAmount=10M,
                    CreateTime=now,
                    IsDeleted=IsDeleted.No
                },
                new AssetRecord{
                    Id=ASSETS_RECORD_ID2,
                    AssetId=ASSETS_ID4,
                    AssetName="测试资产",
                    AggregateAmount=30M,
                    CreateTime=now,
                    IsDeleted=IsDeleted.No
                },
                new AssetRecord{
                    Id=ASSETS_RECORD_ID3,
                    AssetId=ASSETS_ID4,
                    AssetName="测试资产",
                    AggregateAmount=50M,
                    CreateTime=now,
                    IsDeleted=IsDeleted.No
                },
                new AssetRecord{
                    Id=ASSETS_RECORD_ID4,
                    AssetId=ASSETS_ID4,
                    AssetName="测试资产",
                    AggregateAmount=90M,
                    CreateTime=now,
                    IsDeleted=IsDeleted.No
                },
                new AssetRecord{
                    Id=ASSETS_RECORD_ID5,
                    AssetId=ASSETS_ID4,
                    AssetName="测试资产",
                    AggregateAmount=10M,
                    CreateTime=now,
                    IsDeleted=IsDeleted.No
                }
            };
        }
        #endregion
    }
}
