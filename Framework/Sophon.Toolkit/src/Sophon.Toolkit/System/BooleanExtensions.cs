using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// bool值中文描述
        /// True返回是，False返回否
        /// </summary>
        /// <param name="source">源数据</param>
        /// <returns>True返回是False返回被否</returns>
        public static string Description(this bool source)
        {
            return source ? "是" : "否";
        }

        /// <summary>
        /// bool值中文描述
        /// True返回是，False返回否
        /// </summary>
        /// <param name="source">源数据</param>
        /// <returns>如果为Null返回""，如果是True返回是，如果是False返回被否</returns>
        public static string Description(this bool? source)
        {
            return source == null ? "" : source.Value.Description();
        }
    }
}
