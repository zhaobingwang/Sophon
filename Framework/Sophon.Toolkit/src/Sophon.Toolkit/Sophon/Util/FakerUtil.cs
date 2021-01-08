using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit.Sophon.Util
{
    /// <summary>
    /// 假数据生成工具
    /// </summary>
    public static class FakerUtil
    {
        /// <summary>
        /// 简体中文
        /// </summary>
        public const string ZH_CN = "zh_CN";

        /// <summary>
        /// 获取一个中文姓名
        /// </summary>
        /// <returns>中文姓名</returns>
        public static string GetOneChineseName()
        {
            var name = new Bogus.DataSets.Name(ZH_CN);
            var firstName = name.FirstName();
            var lastName = name.LastName();
            return $"{lastName}{firstName}";
        }

        /// <summary>
        /// 获取一个手机/电话号码
        /// </summary>
        /// <returns></returns>
        public static string GetOnePhoneNumber()
        {
            var phone = new Bogus.DataSets.PhoneNumbers(ZH_CN);
            return phone.PhoneNumber();
        }
    }
}
