using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi
{
    public class JwtSettings
    {
        public const string JwtSetting = "JwtSetting";

        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireSeconds { get; set; }
    }
}
