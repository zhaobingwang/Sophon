using Dapper;
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
using Microsoft.Data.SqlClient;

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
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MSSQL")))
            {
                DynamicParameters parameters = new DynamicParameters();
                string where = string.Empty;
                string sqlData = "SELECT * FROM log WHERE 1=1 ";// string.Format("SELECT * FROM logs ORDER BY TIMESTAMP DESC limit {0} offset {0}*{1}", vo.Limit, vo.Page - 1);
                string sqlCount = "SELECT count(1) FROM log WHERE 1=1 ";
                if (vo.StartDate.HasValue)
                {
                    where += "AND timestamp >=@StartDate ";
                    parameters.Add("StartDate", vo.StartDate.Value);
                }
                if (vo.EndDate.HasValue)
                {
                    where += "AND timestamp <=@EndDate ";
                    parameters.Add("EndDate", vo.EndDate.Value.AddDays(1).AddSeconds(-1));
                }

                if (!vo.Level.IsNullOrWhiteSpace())
                {
                    where += "AND Level =@Level ";
                    parameters.Add("Level", vo.Level);
                }

                if (!vo.Message.IsNullOrWhiteSpace())
                {
                    where += "and (Message like @Message ";
                    where += " Exception like @Message) ";
                    parameters.Add("Message", "%" + vo.Message + "%");
                }
                sqlData += where;
                sqlCount += where;

                sqlData = string.Format(sqlData += "order by timestamp desc offset {0}*{1} rows fetch next {0} rows only", vo.Limit, vo.Page - 1);

                var logs = await connection.QueryAsync<Log>(sqlData, parameters);
                var count = await connection.ExecuteScalarAsync<int>(sqlCount, parameters);
                return new LayuiTablePageVO(logs, count, 1, "success");
            }
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(DateTime? startTime, DateTime? endTime)
        {
            using (IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("MSSQL")))
            {
                DynamicParameters parameters = new DynamicParameters();
                string sql = "SELECT * FROM log WHERE 1=1 ";
                string where = string.Empty;
                if (startTime.HasValue)
                {
                    where += "AND timestamp >=@StartDate ";
                    parameters.Add("StartDate", startTime.Value);
                }
                if (endTime.HasValue)
                {
                    where += "AND timestamp <=@EndDate ";
                    parameters.Add("EndDate", endTime.Value.AddDays(1).AddSeconds(-1));
                }
                sql += where;
                var datas = await connection.QueryAsync<Log>(sql, parameters);
                return datas;
            }
        }
    }
}
