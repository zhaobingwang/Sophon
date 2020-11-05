using System;
using Xunit;

namespace Sophon.Toolkit.Tests
{
    public class DateTimeExtensionsTest
    {
        [Fact]
        public void GetWeekOfYear()
        {
            var time = new DateTime(2020, 1, 1);
            int expected = 1;
            int actual = time.GetWeekOfYear();
            Assert.Equal(expected, actual);
        }

        [Theory()]
        [InlineData(true, 0)]
        [InlineData(false, 1)]
        [InlineData(false, -1)]
        public void IsToday(bool isToday, int beAddDays)
        {
            DateTime today = new DateTime(2020, 10, 18, 20, 18, 12);
            var source = today.AddDays(beAddDays);

            Assert.True(source.AddDays(beAddDays).IsToday(today) == isToday);
        }

        [Fact]
        public void StartOfCurrentDay()
        {
            var dateTime = new DateTime(2019, 12, 12, 16, 24, 12);
            var expected = new DateTime(2019, 12, 12, 0, 0, 0);
            Assert.True(dateTime.StartOfCurrentDay() == expected);
        }

        [Fact]
        public void EndOfCurrentDay()
        {
            var dateTime = new DateTime(2019, 12, 12, 16, 24, 12);
            var expected = new DateTime(2019, 12, 12, 23, 59, 59);
            Assert.True(dateTime.EndOfCurrentDay() == expected);
        }

        [Theory(DisplayName = "转为友好的时间信息-成功测试")]
        [InlineData("刚刚", 0)]
        [InlineData("刚刚", 59)]
        [InlineData("1分钟前", 60)]
        [InlineData("1分钟前", 119)]
        [InlineData("2分钟前", 60 * 2)]
        [InlineData("2分钟前", 60 * 2 + 59)]
        [InlineData("1小时前", 60 * 60)]
        [InlineData("1小时前", 60 * 60 * 2 - 1)]
        [InlineData("2小时前", 60 * 60 * 2)]
        [InlineData("2小时前", 60 * 60 * 3 - 1)]
        [InlineData("3小时前", 60 * 60 * 3)]
        [InlineData("3小时前", 60 * 60 * 4 - 1)]
        [InlineData("昨天", 60 * 60 * 24)]
        [InlineData("1天前", 60 * 60 * 24 + 1)]
        [InlineData("1天前", 60 * 60 * 24 * 2 - 1)]
        [InlineData("2天前", 60 * 60 * 24 * 2)]
        [InlineData("6天前", 60 * 60 * 24 * 6)]
        [InlineData("6天前", 60 * 60 * 24 * 7 - 1)]
        [InlineData("上周", 60 * 60 * 24 * 7)]
        [InlineData("上周", 60 * 60 * 24 * 14 - 1)]
        [InlineData("2周前", 60 * 60 * 24 * 14)]
        [InlineData("2周前", 60 * 60 * 24 * 21 - 1)]
        [InlineData("3周前", 60 * 60 * 24 * 21)]
        [InlineData("3周前", 60 * 60 * 24 * 28 - 1)]
        [InlineData("上个月前", 60 * 60 * 24 * 28)]
        [InlineData("上个月前", 60 * 60 * 24 * 60 - 1)]
        [InlineData("2个月前", 60 * 60 * 24 * 60)]
        [InlineData("2个月前", 60 * 60 * 24 * 90 - 1)]
        [InlineData("3个月前", 60 * 60 * 24 * 90)]
        [InlineData("3个月前", 60 * 60 * 24 * 120 - 1)]
        [InlineData("12个月前", 60 * 60 * 24 * 365 - 1)]
        [InlineData("去年", 60 * 60 * 24 * 365)]
        [InlineData("去年", 60 * 60 * 24 * 730 - 1)]
        [InlineData("2年前", 60 * 60 * 24 * 365 * 2)]
        [InlineData("2年前", 60 * 60 * 24 * 365 * 3 - 1)]
        [InlineData("3年前", 60 * 60 * 24 * 365 * 3)]
        public void ToFriendlyDateStringShouldSuccess(string friendlyInfo, int beSubtractSeconds)
        {
            var publishTime = new DateTime(2019, 12, 12, 18, 30, 0);
            var now = new DateTime(2019, 12, 12, 18, 30, 0);

            Assert.True(publishTime.AddSeconds(-1 * beSubtractSeconds).ToFriendlyDateString(now) == friendlyInfo);
        }

        [Theory]
        [InlineData(6, "2020-4-24")]
        [InlineData(28, "2020-2-1")]
        [InlineData(30, "2020-1-1")]
        public void RemainingDaysOfMonth(int days, string dateTimeVal)
        {
            var dateTime = Convert.ToDateTime(dateTimeVal);
            Assert.True(days == dateTime.RemainingDaysOfMonth());
        }

        [Theory]
        [InlineData(364, "1900-1-1")]
        [InlineData(364, "2019-1-1")]
        [InlineData(365, "2020-1-1")]
        [InlineData(0, "2020-12-31")]
        public void RemainingDaysOfYear(int days, string dateTimeVal)
        {
            var dateTime = Convert.ToDateTime(dateTimeVal);
            Assert.True(days == dateTime.RemainingDaysOfYear());
        }


        [Theory()]
        [InlineData(false, 0)]
        [InlineData(false, 1)]
        [InlineData(false, 2)]
        [InlineData(false, 3)]
        [InlineData(false, 4)]
        [InlineData(true, 5)]
        [InlineData(true, 6)]
        public void IsWeekend(bool isWeekend, int beAddDays)
        {
            DateTime monday = new DateTime(2020, 4, 13);
            Assert.True(monday.AddDays(beAddDays).IsWeekend() == isWeekend);
        }

        [Theory(DisplayName = "是否早于指定时间")]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        [InlineData(false, -1)]
        public void IsBefore(bool isBefore, int beAddSeconds)
        {
            var now = DateTime.Now;
            var target = now.AddSeconds(beAddSeconds);
            Assert.True(now.IsEarlierThan(target) == isBefore);
        }

        [Theory(DisplayName = "是否晚于指定时间")]
        [InlineData(false, 1)]
        [InlineData(false, 0)]
        [InlineData(true, -1)]
        public void IsAfter(bool isBefore, int beAddSeconds)
        {
            var now = DateTime.Now;
            var target = now.AddSeconds(beAddSeconds);
            Assert.True(now.IsLaterThan(target) == isBefore);
        }

        [Fact(DisplayName = "转中文日期格式")]
        public void ToChineseDateString()
        {
            var datetime = Convert.ToDateTime("2019-12-11 23:10:10");
            var expected = "2019年12月11日";

            Assert.True(datetime.ToChineseDateString() == expected);
        }

        [Fact(DisplayName = "转中文日期时间格式")]
        public void ToChineseDateTimeStringShouldSuccess()
        {
            var datetime = Convert.ToDateTime("2019-12-11 23:10:10");
            var expected = "2019年12月11日 23时10分10秒";

            Assert.True(datetime.ToChineseDateTimeString() == expected);
        }
        [Fact(DisplayName = "转为yyyy-MM-dd日期格式-成功测试")]
        public void ToDateStringShouldSuccess()
        {
            var datetime = Convert.ToDateTime("2019-12-11 23:10:10");
            var expected = "2019-12-11";

            Assert.True(datetime.ToDateString() == expected);
        }

        [Fact]
        public void ToDateTimeString()
        {
            var datetime = Convert.ToDateTime("2019-12-11 23:10:10");
            var expected = "2019-12-11 23:10:10";
            var expectedWithOutSeconds = "2019-12-11 23:10";

            Assert.True(datetime.ToDateTimeString() == expected);
            Assert.True(datetime.ToDateTimeString(false) == expectedWithOutSeconds);
        }
    }
}
