using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit
{
    /// <summary>
    /// 密码学工具类
    /// </summary>
    public static partial class CryptographyUtil
    {
        /// <summary>
        /// 获取MD5哈希值，默认编码为UTF8
        /// </summary>
        /// <param name="value">待计算的字符串</param>
        /// <returns>32位大写哈希字符串</returns>
        public static string GetMd5Hash(string value, bool toUpper = true)
        {
            return GetMd5Hash(value, Encoding.UTF8, toUpper);
        }

        /// <summary>
        /// 获取MD5哈希值
        /// </summary>
        /// <param name="value">待计算的字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>32位大写哈希字符串</returns>
        public static string GetMd5Hash(string value, Encoding encoding, bool toUpper = true)
        {
            if (value.IsNullOrWhiteSpace())
                return string.Empty;

            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(encoding.GetBytes(value));
                var hash = BitConverter.ToString(hashBytes);

                if (toUpper)
                    return hash.Replace("-", "");
                else
                    return hash.ToLower().Replace("-", "");
            }
        }
    }
}
