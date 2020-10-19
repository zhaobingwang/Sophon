using Microsoft.EntityFrameworkCore;
using Sophon.Infrastructure.Data;
using Sophon.Infrastructure.Entities;
using Sophon.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Infrastructure.Services
{
    public class AssetRecordServices : ISophonAutoDependence
    {
        private readonly SophonDbContext _dbContext;

        public AssetRecordServices(SophonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AssetRecord>> ListAllAsync()
        {
            var list = await _dbContext.AssetRecords.ToListAsync();
            return list;
        }
    }
}
