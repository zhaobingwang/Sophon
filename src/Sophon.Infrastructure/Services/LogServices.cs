﻿using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Sophon.Infrastructure.Entities;
using Sophon.Infrastructure.Interface;
using Sophon.Infrastructure.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sophon.Toolkit;

namespace Sophon.Infrastructure.Services
{
    public class LogServices : ISophonAutoDependence
    {
        private readonly IConfiguration _configuration;

        public LogServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<LayuiTablePageVO> ListPageAsync(QueryLogsVO vo)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("SQLite")))
            {
                DynamicParameters parameters = new DynamicParameters();
                string where = string.Empty;
                string sqlData = "SELECT * FROM logs WHERE 1=1 ";// string.Format("SELECT * FROM logs ORDER BY TIMESTAMP DESC limit {0} offset {0}*{1}", vo.Limit, vo.Page - 1);
                string sqlCount = "SELECT count() FROM logs WHERE 1=1 ";
                if (vo.StartDate.HasValue)
                {
                    where += "AND timestamp >=@StartDate ";
                    parameters.Add("StartDate", vo.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                if (vo.EndDate.HasValue)
                {
                    where += "AND timestamp <=@EndDate ";
                    parameters.Add("EndDate", vo.EndDate.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ss"));
                }

                if (!vo.Level.IsNullOrWhiteSpace())
                {
                    where += "AND Level =@Level ";
                    parameters.Add("Level", vo.Level);
                }

                if (!vo.Message.IsNullOrWhiteSpace())
                {
                    where += "AND (RenderedMessage like @Message ";
                    where += "OR Exception like @Message) ";
                    parameters.Add("Message", "%" + vo.Message + "%");
                }
                sqlData += where;
                sqlCount += where;

                sqlData = string.Format(sqlData += "ORDER BY TIMESTAMP DESC limit {0} offset {0}*{1}", vo.Limit, vo.Page - 1);

                var logs = await connection.QueryAsync<Log>(sqlData, parameters);
                var count = await connection.ExecuteScalarAsync<int>(sqlCount, parameters);
                return new LayuiTablePageVO(logs, count, 1, "success");
            }
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(DateTime? startTime, DateTime? endTime)
        {
            using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("SQLite")))
            {
                DynamicParameters parameters = new DynamicParameters();
                string sql = "SELECT * FROM logs WHERE 1=1 ";
                string where = string.Empty;
                if (startTime.HasValue)
                {
                    where += "AND timestamp >=@StartDate ";
                    parameters.Add("StartDate", startTime.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                if (endTime.HasValue)
                {
                    where += "AND timestamp <=@EndDate ";
                    parameters.Add("EndDate", endTime.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                sql += where;
                var datas = await connection.QueryAsync<Log>(sql, parameters);
                return datas;
            }
        }
    }
}
