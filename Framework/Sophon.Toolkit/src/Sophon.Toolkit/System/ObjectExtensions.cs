using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sophon.Toolkit.Extensions.System
{
    /// <summary>
    /// 对象扩展方法
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// 转为另一个类型
        /// </summary>
        /// <typeparam name="T">要转换的类型</typeparam>
        /// <param name="obj">被转换的对象</param>
        /// <returns>转换后的对象</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// 检查当前元素是否在指定列表中
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">源对象</param>
        /// <param name="list">列表</param>
        /// <returns></returns>
        public static bool IsIn<T>(this T obj, params T[] list)
        {
            return list.Contains(obj);
        }
    }
}
