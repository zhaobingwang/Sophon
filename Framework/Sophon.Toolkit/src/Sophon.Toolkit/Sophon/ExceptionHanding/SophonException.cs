using System;
using System.Collections.Generic;
using System.Text;

namespace Sophon.Toolkit.Sophon.ExceptionHanding
{
    /// <summary>
    /// Sophon应用异常基类
    /// </summary>
    public class SophonException : Exception
    {
        /// <summary>
        /// 初始化一个<see cref="SophonException"/>新实例
        /// </summary>
        public SophonException()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SophonException"/>新实例
        /// </summary>
        /// <param name="message">异常信息</param>
        public SophonException(string message) : base(message)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SophonException"/>新实例
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        public SophonException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
