using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sophon.Toolkit.Biz.Enums
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// 男性
        /// </summary>
        [Description("男")]
        Male = 1,

        /// <summary>
        /// 女性
        /// </summary>
        [Description("女")]
        Famale = 2,
    }

    /// <summary>
    /// 性别扩展
    /// </summary>
    public static class GenderExtensions
    {
        /// <summary>
        /// 获取性别<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息
        /// </summary>
        /// <param name="gender">性别</param>
        /// <returns>性别<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息</returns>
        public static string Description(this Gender? gender)
        {
            return gender == null ? string.Empty : gender.Value.Description();
        }

        /// <summary>
        /// 获取性别值
        /// </summary>
        /// <param name="gender">性别</param>
        /// <returns>性别值</returns>
        public static int? Value(this Gender? gender)
        {
            return gender?.Value();
        }
    }
}
