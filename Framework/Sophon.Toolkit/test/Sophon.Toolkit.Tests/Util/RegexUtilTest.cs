using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.Tests.Util
{
    [Trait("工具类", "正则")]
    public class RegexUtilTest
    {
        [Fact(DisplayName = "手机号-正常参数测试")]
        public void Match_MobileNumber_ShouldBeTrue()
        {
            // Arrange
            var mobileNumber = "13800000000";

            // Act
            var result = RegexUtil.IsMatch(mobileNumber, Const.RegexPattern.MobileNumber);

            // Assert
            Assert.True(result);
        }
    }
}
