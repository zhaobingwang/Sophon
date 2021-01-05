using Sophon.Toolkit.Biz.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sophon.Toolkit.Tests
{
    public class GenderTest
    {
        [Fact]
        public void GetValue()
        {
            // Arrange
            var gender = Gender.Male;
            var expected = 1;

            // Act
            var result = gender.Value();

            // Assert
            Assert.True(result == expected);
        }

        [Fact]
        public void GetDescription()
        {
            // Arrange
            var gender = Gender.Famale;
            var expected = "女";

            // Act
            var result = gender.Description();

            // Assert
            Assert.True(result == expected);
        }
    }
}
