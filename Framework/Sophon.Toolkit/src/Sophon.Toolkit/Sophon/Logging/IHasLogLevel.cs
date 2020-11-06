using Microsoft.Extensions.Logging;

namespace Sophon.Toolkit.Logging
{
    /// <summary>
    /// 定义了日志等级<see cref="LogLevel"/>接口
    /// </summary>
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
