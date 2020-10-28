using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.Entities
{
    /// <summary>
    /// 日志实体类
    /// 不需要再EF中生成表，此结构与Serilog匹配
    /// </summary>
    public class Log
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Level { get; set; }
        public string Exception { get; set; }
        public string RenderedMessage { get; set; }
        public string Properties { get; set; }
    }
}
