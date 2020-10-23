using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.DV.Echarts
{
    public static class FakeData
    {
        public static DataSets ProductData()
        {
            List<string[]> row = new List<string[]>();
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    string[] cur = new string[] {
                        "product",
                        DateTime.Now.AddYears(-5).Year.ToString(),
                        DateTime.Now.AddYears(-4).Year.ToString(),
                        DateTime.Now.AddYears(-3).Year.ToString(),
                        DateTime.Now.AddYears(-2).Year.ToString(),
                        DateTime.Now.AddYears(-1).Year.ToString(),
                        DateTime.Now.Year.ToString(),
                    };
                    row.Add(cur);
                }
                else
                {
                    string[] cur = new string[] {
                        GetProductName(i),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                    };
                    row.Add(cur);
                }
            }
            DataSets data = new DataSets();
            data.Source = row;

            return data;
        }

        private static string GetProductName(int i)
        {

            switch (i)
            {
                case 1:
                    return "手机";
                case 2:
                    return "服饰";
                case 3:
                    return "日用";
                case 4:
                    return "电脑";
                default:
                    return "未知";
            }
        }
    }
}
