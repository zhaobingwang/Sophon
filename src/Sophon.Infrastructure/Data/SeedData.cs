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
        public static async Task SeedAsync(IServiceProvider provider)
        {
            var now = DateTime.UtcNow;
            var dbContext = provider.GetService<SophonDbContext>();
            if (!dbContext.Assets.Any())
            {
                dbContext.Assets.AddRange(new List<Asset> {
                    new Asset{
                        Name="个人资产",
                        AggregateAmount=10M,
                        IsDeleted=IsDeleted.No,
                        CreateTime=now,
                        ModifyTime=now,
                    },
                    new Asset{
                        Name="父母的养老金",
                        AggregateAmount=20M,
                        IsDeleted=IsDeleted.No,
                        CreateTime=now,
                        ModifyTime=now,
                    },
                    new Asset{
                        Name="公积金账户",
                        AggregateAmount=5M,
                        IsDeleted=IsDeleted.No,
                        CreateTime=now,
                        ModifyTime=now,
                    },
                });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
