using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            ErrorCode = 0;
            ErrorMessage = "请求成功";
        }
        [JsonPropertyName("errCode")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("errMsg")]
        public string ErrorMessage { get; set; }
    }
}
