using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sophon.Toolkit
{
    public class ReflectionUtil
    {
        /// <summary>
        /// 获取对象的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="memberName">对象成员名</param>
        /// <returns>对象的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息</returns>
        public static string GetDescription(Type type, string memberName)
        {
            if (type == null)
                return string.Empty;
            if (memberName.IsNullOrWhiteSpace())
                return string.Empty;

            return GetDescription(type.GetTypeInfo().GetMember(memberName).FirstOrDefault());
        }

        /// <summary>
        /// 获取对象的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息
        /// </summary>
        /// <param name="memberInfo">对象成员</param>
        /// <returns>对象的<see cref="System.ComponentModel.DescriptionAttribute"/>特性信息</returns>
        public static string GetDescription(MemberInfo memberInfo)
        {
            if (memberInfo == null)
                return string.Empty;
            return memberInfo.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attribute ? attribute.Description : memberInfo.Name;
        }
    }
}
