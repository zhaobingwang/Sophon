using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace Sophon.Toolkit
{
    /// <summary>
    /// Json工具类
    /// </summary>
    public static partial class JsonUtil
    {
        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <typeparam name="T">目标对象类型</typeparam>
        /// <param name="json">Json字符串</param>
        /// <returns>目标对象</returns>
        public static T ToObject<T>(string json)
        {
            if (json.IsNullOrWhiteSpace())
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <returns>Json字符串</returns>
        public static string ToJson(object target)
        {
            if (target == null)
                return string.Empty;
            var options = new JsonSerializerOptions();
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All);
            var result = JsonSerializer.Serialize(target, options);
            return result;
        }
    }
}
