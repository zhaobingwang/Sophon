using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.Tests
{
    [Trait("工具类", "Guid")]
    public class GuidGeneratorTest
    {
        [Fact]
        public void Create_A_Guid()
        {
            var guid = GuidGenerator.Instance.Create();
            Assert.True(guid.ToString().Length == 36);
        }
    }
}
