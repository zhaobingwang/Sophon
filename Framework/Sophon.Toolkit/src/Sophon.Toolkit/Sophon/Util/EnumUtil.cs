using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Toolkit
{
    public class EnumUtil
    {
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">枚举成员</param>
        /// <returns>枚举值</returns>
        public static int GetValue(Type type, object member)
        {
            return (int)Enum.Parse(type, member?.ToString(), true);
        }

        /// <summary>
        /// 获取枚举的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">枚举成员</param>
        /// <returns>枚举的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息</returns>
        public static string GetDescription(Type type, object member)
        {
            return ReflectionUtil.GetDescription(type, Enum.GetName(type, member));
        }
    }
}
