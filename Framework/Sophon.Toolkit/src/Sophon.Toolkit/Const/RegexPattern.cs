using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Const
{
    /// <summary>
    /// 正则表达式模式字符串
    /// </summary>
    public static class RegexPattern
    {
        /// <summary>
        /// 身份证验证正则表达式
        /// </summary>
        public static string IdCard = @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)";

        /// <summary>
        /// 手机号码验证正则表达式
        /// </summary>
        public static string MobileNumber = "^1[0-9]{10}$";
    }
}
