using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Template.RBAC.WebApi.Data
{
    /// <summary>
    /// 种子数据
    /// </summary>
    public class SeedData
    {
        static DateTime now;

        /// <summary>
        /// 
        /// </summary>
        static SeedData()
        {
            now = DateTime.UtcNow;
        }

        /// <summary>
        /// 播种数据
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static async Task SeedAsync(IServiceProvider provider)
        {
            var dbContext = provider.GetService<TemplateDbContext>();
            if (!dbContext.SysUser.Any())
            {
                var users = Faker.GetSysUser();
                await dbContext.SysUser.AddRangeAsync(users);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
