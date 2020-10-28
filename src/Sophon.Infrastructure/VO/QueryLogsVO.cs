using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.VO
{
    public class QueryLogsVO
    {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
