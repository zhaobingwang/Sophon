using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophon.Toolkit
{
    /// <summary>
    /// Guid帮助类
    /// </summary>
    public class GuidGenerator
    {
        public static GuidGenerator Instance { get; } = new GuidGenerator();
        public virtual Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
