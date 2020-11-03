using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Sophon.DV.Echarts;
using Sophon.Infrastructure.Services;
using Sophon.Infrastructure.VO;

namespace Sophon.Web.Controllers.Api
{
    [Route("api/log")]
    [ApiController]
    public class LogApiController : ControllerBase
    {
        private readonly LogServices _logServices;

        public LogApiController(LogServices logServices)
        {
            _logServices = logServices;
        }

        [HttpPost("listpage")]
        public async Task<IActionResult> ListPage([FromForm] QueryLogsVO vo)
        {
            var result = await _logServices.ListPageAsync(vo);
            return Ok(result);
        }

        [HttpGet("statistics/today")]
        public async Task<IActionResult> TodayLogs()
        {
            var now = DateTime.Now;
            List<string> level = new List<string> { "Debug", "Information", "Warning", "Error", "Fatal" };
            List<string[]> rows = new List<string[]>();
            string[] lineOne = GetHours();
            rows.Add(FormatRowData("Level", lineOne));


            // 获取当日所有日志
            var todayLogs = await _logServices.GetLogsAsync(now.StartOfCurrentDay(), now.EndOfCurrentDay());
            for (int i = 0; i < level.Count; i++)
            {
                var current = new string[lineOne.Length];
                // 当前等级日志按小时分组
                var curLevelLogs = todayLogs.Where(x => x.Level == level[i])
                    .GroupBy(x => x.Timestamp.Hour.ToString().PadLeft(2, '0') + ":00")
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Count(y => true).ToString()))
                    .OrderBy(x => x.Key)
                    .ToList();

                // 当前时辰不存在记录则返回0
                for (int j = 0; j < lineOne.Length; j++)
                {
                    var exists = curLevelLogs.Count(x => x.Key == lineOne[j]) == 1;
                    current[j] = exists ? curLevelLogs.FirstOrDefault(x => x.Key == lineOne[j]).Value : "0";
                }

                // 添加当前行数据
                rows.Add(FormatRowData(level[i], current));
            }
            DataSets dataSets = new DataSets();
            dataSets.Source = rows;
            return Ok(dataSets);
        }

        [HttpGet("statistics/latestndays")]
        public async Task<IActionResult> Latest7DaysLogs(int latestDays = 7)
        {
            string dateFormat = "yyyy年MM月dd日";
            if (latestDays < 0 || latestDays > 15)
            {
                return Ok("nameof(latestDays)}最大不能超过15且不能小于0");
            }
            if (latestDays > 7)
            {
                dateFormat = "yyyyMMdd";
            }
            var now = DateTime.Now;
            List<string> level = new List<string> { "Debug", "Information", "Warning", "Error", "Fatal" };
            List<string[]> rows = new List<string[]>();

            string[] lineOne = GetLatestNDays(now, latestDays, dateFormat);
            rows.Add(FormatRowData("Level", lineOne));

            // 获取当日所有日志
            var latest7DaysLogs = await _logServices.GetLogsAsync(now.AddDays(-1 * latestDays).StartOfCurrentDay(), now.EndOfCurrentDay());
            for (int i = 0; i < level.Count; i++)
            {
                var current = new string[lineOne.Length];
                // 当前等级日志按天分组
                var curLevelLogs = latest7DaysLogs.Where(x => x.Level == level[i])
                    .GroupBy(x => x.Timestamp.Date.ToString(dateFormat))
                    .Select(x => new KeyValuePair<string, string>(x.Key, x.Count(y => true).ToString()))
                    .OrderBy(x => x.Key)
                    .ToList();
                // 当天不存在记录则返回0
                for (int j = 0; j < lineOne.Length; j++)
                {
                    var curDay = DateTime.Now.AddDays(j - latestDays + 1).ToString(dateFormat);
                    var exists = curLevelLogs.Count(x => x.Key == curDay) == 1;
                    current[j] = exists ? curLevelLogs.FirstOrDefault(x => x.Key == curDay).Value : "0";
                }
                // 添加当前行数据
                rows.Add(FormatRowData(level[i], current));
            }
            DataSets dataSets = new DataSets();
            dataSets.Source = rows;
            return Ok(dataSets);
        }

        private string[] FormatRowData(string category, string[] datas)
        {
            string[] header = new string[datas.Length + 1];
            header[0] = category;
            for (int i = 0; i < datas.Length; i++)
            {
                header[i + 1] = datas[i];
            }
            return header;
        }

        private string[] GetHours()
        {
            const int MAX_HOUR = 24;
            string[] result = new string[MAX_HOUR];
            for (int i = 0; i < MAX_HOUR; i++)
            {
                result[i] = i.ToString().PadLeft(2, '0') + ":00";
            }
            return result;
        }

        private string[] GetLatestNDays(DateTime now, int maxDays, string dateFormat)
        {
            string[] result = new string[maxDays];
            for (int i = 0; i < maxDays; i++)
            {
                result[i] = DateTime.Now.AddDays(i - maxDays + 1).ToString(dateFormat);
            }
            return result;
        }
    }
}
