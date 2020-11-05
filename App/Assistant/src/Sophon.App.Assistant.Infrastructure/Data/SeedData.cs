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
        #region 资产分类
        const string ASSET_TYPE_CODE_MY = "MY_ASSETS";
        const string ASSET_TYPE_NAME_MY = "我的资产";
        const string ASSET_TYPE_CODE_COMMON_RESERVE_FUND = "COMMON_RESERVE_FUND";
        const string ASSET_TYPE_NAME_COMMON_RESERVE_FUND = "公积金";
        const string ASSET_TYPE_CODE_PARENTS_PENSION = "PARENTS_PENSION";
        const string ASSET_TYPE_NAME_PARENTS_PENSION = "父母的养老金";
        #endregion

        const int ASSETS_RECORD_ID1 = 1;
        const int ASSETS_RECORD_ID2 = 2;
        const int ASSETS_RECORD_ID3 = 3;
        const int ASSETS_RECORD_ID4 = 4;
        const int ASSETS_RECORD_ID5 = 5;
        public static async Task SeedAsync(IServiceProvider provider)
        {
            var now = DateTime.UtcNow;
            var dbContext = provider.GetService<SophonDbContext>();
            if (!dbContext.AssetTypes.Any())
            {
                dbContext.AssetTypes.AddRange(GetAssetType());
                await dbContext.SaveChangesAsync();
            }
        }

        #region FakeData & Default Data
        private static List<AssetType> GetAssetType()
        {
            List<AssetType> assetTypes = new List<AssetType>();

            #region 默认类型
            assetTypes.Add(new AssetType
            {
                Code = ASSET_TYPE_CODE_MY,
                Name = ASSET_TYPE_NAME_MY,
                Method = 0
            });
            assetTypes.Add(new AssetType
            {
                Code = ASSET_TYPE_CODE_COMMON_RESERVE_FUND,
                Name = ASSET_TYPE_NAME_COMMON_RESERVE_FUND,
                Method = 0
            });
            assetTypes.Add(new AssetType
            {
                Code = ASSET_TYPE_CODE_PARENTS_PENSION,
                Name = ASSET_TYPE_NAME_PARENTS_PENSION,
                Method = 0
            });
            #endregion

            #region 存储介质类型
            assetTypes.Add(new AssetType
            {
                Code = "ALIPAY_TOTAL",
                Name = "支付宝总资产",
                Method = 1
            });
            assetTypes.Add(new AssetType
            {
                Code = "QIEMAN_TOTAL",
                Name = "且慢总资产",
                Method = 1
            });
            assetTypes.Add(new AssetType
            {
                Code = "Bank_TOTAL",
                Name = "银行总资产",
                Method = 1
            });
            assetTypes.Add(new AssetType
            {
                Code = "WX_TOTAL",
                Name = "微信总资产",
                Method = 1
            });
            #endregion

            return assetTypes;
        }
        #endregion
    }
}
