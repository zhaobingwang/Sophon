using Sophon.Toolkit.Extensions.System;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sophon.Toolkit.Tests
{
    public class ObjectExtensionsTest
    {
        [Fact]
        public void As_Test()
        {
            var obj = (object)new ObjectExtensionsTest();
            Assert.NotNull(obj.As<ObjectExtensionsTest>());

            obj = null;
            Assert.Null(obj.As<ObjectExtensionsTest>());
        }

        [Fact]
        public void IsIn_Test()
        {
            Assert.True(1.IsIn(1, 2, 3));
            Assert.False(1.IsIn(2, 3));
            Assert.True("1".IsIn("1", "2", "3"));

            string str = null;
            Assert.False(str.IsIn("1", "2", "3"));

            int? num = null;
            Assert.False(num.IsIn(1, 2, 3));
        }
    }
}
