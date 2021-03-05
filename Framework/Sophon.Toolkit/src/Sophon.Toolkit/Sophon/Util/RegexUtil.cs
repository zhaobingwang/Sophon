using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sophon.Toolkit
{
    public static partial class RegexUtil
    {
        public static bool IsMatch(string value, string pattern)
        {
            return Regex.IsMatch(value, pattern);
        }
    }
}
