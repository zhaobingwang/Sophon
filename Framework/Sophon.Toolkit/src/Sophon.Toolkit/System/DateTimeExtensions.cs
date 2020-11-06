using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace System
{
    /// <summary>
    /// <see cref="System.DateTime"/>扩展类
    /// </summary>
    public static partial class DateTimeExtensions
    {
        /// <summary>
        /// 周未
        /// </summary>
        public static readonly DayOfWeek[] Weekend = { DayOfWeek.Saturday, DayOfWeek.Sunday };


        /// <summary>
        /// 获取当前指定的时间是一年中的第几周
        /// <list type="bullet">
        /// <item>
        /// 年的第一周从该年的第一天开始，到所指定周的下一个首日前结束
        /// </item>
        /// <item>
        /// 每周的第一天为周一
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="time">源数据</param>
        /// <returns>周数</returns>
        public static int GetWeekOfYear(this DateTime time)
        {
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// 转为当天的最晚时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime EndOfCurrentDay(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, 23, 59, 59);
        }

        /// <summary>
        /// 转为当天最早的时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime StartOfCurrentDay(this DateTime time)
        {
            return new DateTime(time.Year, time.Month, time.Day, 0, 0, 0);
        }

        /// <summary>
        /// 指定时间是否为今天
        /// </summary>
        /// <param name="time">源数据</param>
        /// <param name="today">今天的日期</param>
        /// <returns></returns>
        public static bool IsToday(this DateTime time, DateTime? today)
        {
            if (today == null)
                today = DateTime.Now;
            return time.Date == today.Value.Date;
        }

        /// <summary>
        /// 转为友好的时间信息
        /// 比如：1分钟前，3天前等
        /// XXX:一些较复杂判断先简单处理实现，比如昨天，上周，上个月等
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="now">如果为null,则取DateTime.Now</param>
        /// <returns></returns>
        public static string ToFriendlyDateString(this DateTime dateTime, DateTime? now = null)
        {
            if (now == null)
                now = DateTime.Now;
            var timeSince = now.Value.Subtract(dateTime);
            if (timeSince.TotalMinutes < 1)
                return "刚刚";
            if (timeSince.TotalMinutes < 2)
                return "1分钟前";
            if (timeSince.TotalMinutes < 60)
                return $"{timeSince.Minutes}分钟前";
            if (timeSince.TotalMinutes < 120)
                return "1小时前";
            if (timeSince.TotalHours < 24)
                return $"{timeSince.Hours}小时前";
            if (timeSince.TotalDays == 1)
                return "昨天";
            if (timeSince.TotalDays < 7)
                return $"{timeSince.Days}天前";
            if (timeSince.TotalDays < 14)
                return "上周";
            if (timeSince.TotalDays < 21)
                return "2周前";
            if (timeSince.TotalDays < 28)
                return "3周前";
            if (timeSince.TotalDays < 60)
                return "上个月前";
            if (timeSince.TotalDays < 365)
                return $"{Math.Floor(timeSince.TotalDays / 30)}个月前";
            if (timeSince.TotalDays < 730)
                return "去年";
            return $"{Math.Floor(timeSince.TotalDays / 365)}年前";
        }

        /// <summary>
        /// 获取当月剩余天数
        /// </summary>
        /// <param name="dateTime">源日期时间</param>
        /// <returns></returns>
        public static int RemainingDaysOfMonth(this DateTime dateTime)
        {
            var lastDate = new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
            var days = (lastDate - dateTime).TotalDays;
            return (int)Math.Ceiling(days);
        }

        /// <summary>
        /// 获取当年剩余天数
        /// </summary>
        /// <param name="dateTime">源日期时间</param>
        /// <returns></returns>
        public static int RemainingDaysOfYear(this DateTime dateTime)
        {
            var lastDate = new DateTime(dateTime.Year, 12, 31);
            double days = (lastDate - dateTime).TotalDays;
            return (int)Math.Ceiling(days);
        }

        /// <summary>
        /// 是否是周末
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dateTime)
        {
            return Weekend.Any(d => d == dateTime.DayOfWeek);
        }

        /// <summary>
        /// 是否早于指定时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="targetDateTime">目标时间</param>
        /// <returns></returns>
        public static bool IsEarlierThan(this DateTime dateTime, DateTime targetDateTime)
        {
            return dateTime.CompareTo(targetDateTime) < 0;
        }

        /// <summary>
        /// 是否晚于指定时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="targetDateTime"></param>
        /// <returns></returns>
        public static bool IsLaterThan(this DateTime dateTime, DateTime targetDateTime)
        {
            return dateTime.CompareTo(targetDateTime) > 0;
        }

        /// <summary>
        /// 转为中文日期
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <returns>yyyy年MM月dd日 </returns>
        public static string ToChineseDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 转为中文日期时间
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="withSecond">是否包含秒值</param>
        /// <returns>yyyy年MM月dd日 HH时mm分ss秒</returns>
        public static string ToChineseDateTimeString(this DateTime dateTime, bool withSecond = true)
        {
            if (withSecond)
                return dateTime.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            return dateTime.ToString("yyyy年MM月dd日 HH时mm分");
        }

        /// <summary>
        /// 转为 yyyy-MM-dd 格式字符串
        /// </summary>
        /// <param name="dateTime">时间日期</param>
        /// <returns>yyyy-MM-dd</returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 转为 yyyy-MM-dd HH:mm:ss 格式字符串
        /// </summary>
        /// <param name="dateTime">日期时间</param>
        /// <param name="withSecond">是否包含秒值</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DateTime dateTime, bool withSecond = true)
        {
            if (withSecond)
                return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
