using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sophon.Toolkit.Tests.Util
{
    [Trait("工具类", "密码学")]
    public class CryptographyUtilTest
    {
        [Fact(DisplayName = "获取大写MD5值-正常参数测试")]
        public void GetUppercaseMd5_ShouldSuccess_WithExpectedParameters()
        {
            // Arrange
            var source = "123456";
            var expected = "E10ADC3949BA59ABBE56E057F20F883E";
            // Act
            var actual = CryptographyUtil.GetMd5Hash(source);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "获取MD5值-异常参数测试")]
        public void GetUppercaseMd5_ShouldSuccess_WithUnExpectedParameters()
        {
            // Arrange
            var source = "";
            var expected = string.Empty;
            // Act
            var actual = CryptographyUtil.GetMd5Hash(source);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact(DisplayName = "获取小写MD5值-正常参数测试")]
        public void GetLowercaseMd5_ShouldSuccess_WithExpectedParameters()
        {
            // Arrange
            var source = "123456";
            var expected = "e10adc3949ba59abbe56e057f20f883e";
            // Act
            var actual = CryptographyUtil.GetMd5Hash(source, Encoding.UTF8, false);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
