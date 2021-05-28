using System;
using System.Collections.Generic;
using System.IO;
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
        #region MD5
        /// <summary>
        /// 获取MD5哈希值，默认编码为UTF8
        /// </summary>
        /// <param name="value">待计算的字符串</param>
        /// <param name="toUpper">转为大写输出</param>
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
        /// <param name="toUpper">转为大写输出</param>
        /// <returns>32位哈希字符串</returns>
        public static string GetMd5Hash(string value, Encoding encoding, bool toUpper = true)
        {
            if (value.IsNullOrWhiteSpace())
                return string.Empty;

            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(encoding.GetBytes(value));
                var hash = BitConverter.ToString(hashBytes);

                hash = hash.Replace("-", "");
                if (toUpper)
                    return hash;
                else
                    return hash.ToLower();
            }
        }

        /// <summary>
        /// 获取当前流的MD5哈希值
        /// </summary>
        /// <param name="stream">当前流</param>
        /// <param name="toUpper">转为大写输出</param>
        /// <returns>32位哈希字符串</returns>
        public static string GetMd5Hash(Stream stream, bool toUpper = true)
        {
            if (stream == null)
            {
                return string.Empty;
            }
            using (var md5 = MD5.Create())
            {
                var hashByte = md5.ComputeHash(stream);
                var hash = BitConverter.ToString(hashByte);
                hash = hash.Replace("-", "");
                if (toUpper)
                    return hash;
                else
                    return hash.ToLower();
            }
        }
        #endregion
    }
}
