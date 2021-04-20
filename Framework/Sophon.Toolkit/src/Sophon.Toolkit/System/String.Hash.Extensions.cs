using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class HashExtensions
    {
        /// <summary>
        /// 获取指定字符串的SHA256哈希值
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>哈希值</returns>
        public static string Sha256(this string input)
        {
            if (input.IsNullOrEmpty()) return string.Empty;
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// 获取指定字节数组的SHA256哈希值
        /// </summary>
        /// <param name="input">源字节数组</param>
        /// <returns>哈希值</returns>
        public static byte[] Sha256(this byte[] input)
        {
            if (input == null) return null;
            using (var sha = SHA256.Create())
            {
                return sha.ComputeHash(input);
            }
        }

        /// <summary>
        /// 获取指定字符串的SHA512哈希值
        /// </summary>
        /// <param name="input">源字符串</param>
        /// <returns>哈希值</returns>
        public static string Sha512(this string input)
        {
            if (input.IsNullOrEmpty()) return string.Empty;
            using (var sha = SHA512.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
