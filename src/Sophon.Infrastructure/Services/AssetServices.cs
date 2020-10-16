using Microsoft.EntityFrameworkCore;
using Sophon.Infrastructure.Data;
using Sophon.Infrastructure.Entities;
using Sophon.Infrastructure.VO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Infrastructure.Services
{
    public class AssetServices
    {
        private readonly SophonDbContext dbContext;

        public AssetServices(SophonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Asset>> TotalStatistics()
        {
            return await dbContext.Assets.ToListAsync();
        }

        public async Task<AssetWeeklyStatistics> WeeklyStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
