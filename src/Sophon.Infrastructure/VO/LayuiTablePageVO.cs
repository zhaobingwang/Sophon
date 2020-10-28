using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Infrastructure.VO
{
    public class LayuiTablePageVO
    {
        public LayuiTablePageVO()
        {

        }
        public LayuiTablePageVO(IEnumerable data, int totalCount, int code, string msg = null)
        {
            Data = data;
            Count = totalCount;
        }

        public int Code { get; set; }
        public string Msg { get; set; }
        public int Count { get; set; }
        public object Data { get; set; }
    }
}
