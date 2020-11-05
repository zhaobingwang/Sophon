using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sophon.Toolkit.Tests
{
    public class ThrowIfTest
    {
        [Fact]
        public void IsNullOrEmpty_ThrowNullException_WithNull()
        {
            string str = null;
            Assert.Throws<ArgumentException>(() => ThrowIf.IsNullOrEmpty(str, nameof(str)));
        }

        [Fact]
        public void IsNullOrWhiteSpace_ThrowNullException_WithNull()
        {
            string str = null;
            Assert.Throws<ArgumentException>(() => ThrowIf.IsNullOrWhiteSpace(str, nameof(str)));
        }

        [Fact]
        public void IsNull_ThrowNullException_WithNullObject()
        {
            Sample sample = null;
            Assert.Throws<ArgumentNullException>(() => ThrowIf.IsNull(sample, nameof(sample)));
        }

        [Fact]
        public void IsInRange_ThrowArgumentException_WithOutRangeParameters()
        {
            string str = "hello,world.";    // len = 12
            Assert.Throws<ArgumentException>(() => ThrowIf.IsInRange(str, nameof(str), 11, 2));
        }

        [Fact]
        public void IsInRange_ReturnSourceValue_WithInRangeParameters()
        {
            string str = "hello,world.";    // len = 12
            var result = ThrowIf.IsInRange(str, nameof(str), 12, 2);
            Assert.True(str == result);
        }
    }
}
