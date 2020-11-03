﻿using System;
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
            int xSize = 25;
            List<string> level = new List<string> { "Debug", "Information", "Warning", "Error", "Fatal" };
            List<string[]> row = new List<string[]>();
            string[] current = new string[xSize];
            for (int i = 0; i < xSize; i++)
            {
                if (i == 0)
                {
                    current[i] = "Level";
                }
                else
                {
                    current[i] = $"{i - 1}";
                }
            }
            row.Add(current);

            // 获取当日所有日志
            var now = DateTime.Now;
            var todayLogs = await _logServices.GetLogsAsync(now.StartOfCurrentDay(), now.EndOfCurrentDay());
            for (int i = 0; i < level.Count; i++)
            {
                current = new string[xSize];
                var curLevelLogs = todayLogs.Where(x => x.Level == level[i]).GroupBy(x => x.Timestamp.Hour.ToString()).Select(x => new KV { Key = x.Key, Value = x.Count(y => true).ToString() }).ToList();

                for (int j = 0; j < xSize; j++)
                {
                    if (j == 0)
                    {
                        current[j] = level[i];
                    }
                    else
                    {
                        var exists = curLevelLogs.Count(x => x.Key == (j - 1).ToString()) == 1;
                        current[j] = exists ? curLevelLogs.FirstOrDefault(x => x.Key == (j - 1).ToString()).Value : "0";
                    }
                }
                row.Add(current);
            }
            DataSets dataSets = new DataSets();
            dataSets.Source = row;
            return Ok(dataSets);
        }

        [HttpGet("statistics/latest7days")]
        public async Task<IActionResult> Latest7DaysLogs()
        {
            int xSize = 8;
            List<string> level = new List<string> { "Debug", "Information", "Warning", "Error", "Fatal" };
            List<string[]> row = new List<string[]>();
            string[] current = new string[xSize];
            for (int i = 0; i < xSize; i++)
            {
                if (i == 0)
                {
                    current[i] = "Level";
                }
                else
                {
                    current[i] = DateTime.Now.AddDays(i - xSize + 1).ToString("yyyyMMdd"); // $"{i - 1}";
                }
            }
            row.Add(current);

            // 获取当日所有日志
            var now = DateTime.Now;
            var latest7DaysLogs = await _logServices.GetLogsAsync(now.AddDays(-7).StartOfCurrentDay(), now.EndOfCurrentDay());
            for (int i = 0; i < level.Count; i++)
            {
                current = new string[xSize];
                var curLevelLogs = latest7DaysLogs.Where(x => x.Level == level[i]).GroupBy(x => x.Timestamp.Date.ToString("yyyyMMdd")).Select(x => new KV { Key = x.Key, Value = x.Count(y => true).ToString() }).ToList();

                for (int j = 0; j < xSize; j++)
                {
                    if (j == 0)
                    {
                        current[j] = level[i];
                    }
                    else
                    {
                        var curDay = DateTime.Now.AddDays(j - xSize + 1).ToString("yyyyMMdd");
                        var exists = curLevelLogs.Count(x => x.Key == curDay) == 1;
                        current[j] = exists ? curLevelLogs.FirstOrDefault(x => x.Key == curDay).Value : "0";
                    }
                }
                row.Add(current);
            }
            DataSets dataSets = new DataSets();
            dataSets.Source = row;
            return Ok(dataSets);
        }

        private class KV
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
