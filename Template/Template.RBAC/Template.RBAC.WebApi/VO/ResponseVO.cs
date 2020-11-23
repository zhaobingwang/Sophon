using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.RBAC.WebApi.VO
{
    /// <summary>
    /// 响应视图对象
    /// </summary>
    public class ResponseVO
    {

        /// <summary>
        /// 响应码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 创建一个<see cref="ResponseVO"/>对象实例
        /// 默认返回code=200，message="接口调用成功"
        /// </summary>
        public ResponseVO()
        {
            Code = 0;
            Message = "接口调用成功";
        }

        /// <summary>
        /// 设置响应结果为成功
        /// </summary>
        /// <param name="message"></param>
        public void SetSuccess(string message = "操作成功")
        {
            Code = 0;
            Message = message;
        }

        /// <summary>
        /// 设置响应结果为失败
        /// </summary>
        /// <param name="message"></param>
        public void SetFailed(string message = "操作失败")
        {
            Code = 1001;
            Message = message;
        }

        /// <summary>
        /// 设置响应结果为错误
        /// </summary>
        /// <param name="message"></param>
        public void SetError(string message = "发生了一些错误")
        {
            Code = 2001;
            Message = message;
        }

        /// <summary>
        /// 设置响应数据
        /// </summary>
        /// <param name="data">响应数据</param>
        public void SetData(object data)
        {
            Data = data;
        }
    }
}
