using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.VO
{
    public class AssetWeeklyStatistics
    {
        public AssetStatisticsUnit Monday { get; set; }
        public AssetStatisticsUnit Tuesday { get; set; }
        public AssetStatisticsUnit Wednesday { get; set; }
        public AssetStatisticsUnit Thursday { get; set; }
        public AssetStatisticsUnit Friday { get; set; }
        public AssetStatisticsUnit Saturday { get; set; }
        public AssetStatisticsUnit Sunday { get; set; }
    }
}
