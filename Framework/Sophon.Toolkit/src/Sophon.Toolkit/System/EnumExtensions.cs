using Sophon.Toolkit;
using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    /// <summary>
    /// System.Enum 扩展
    /// </summary>
    public static partial class EnumExtensions
    {
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="source">枚举源数据</param>
        /// <returns>枚举值</returns>
        public static int Value(this Enum source)
        {
            return source == null ? 0 : EnumUtil.GetValue(source.GetType(), source);
        }

        /// <summary>
        /// 获取枚举的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息
        /// </summary>
        /// <param name="source">枚举源数据</param>
        /// <returns><see cref="System.ComponentModel.DescriptionAttribute"/>特性信息</returns>
        public static string Description(this Enum source)
        {
            return source == null ? string.Empty : EnumUtil.GetDescription(source.GetType(), source);
        }
    }
}
