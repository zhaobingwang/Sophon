using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApi
{
    public class ApiInfos
    {
        public const string AppInfo = "AppInfo";
        public string Name { get; set; }
        public string Lang { get; set; }
        public string LatestVersion { get; set; }
    }
}
