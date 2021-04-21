using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi
{
    public class GetAccessTokenResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
