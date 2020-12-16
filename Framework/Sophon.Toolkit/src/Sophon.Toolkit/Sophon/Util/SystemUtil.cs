using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Sophon.Toolkit
{
    /// <summary>
    /// 系统工具类
    /// </summary>
    public static class SystemUtil
    {
        /// <summary>
        /// 是否是Unix操作系统
        /// </summary>
        /// <returns></returns>
        public static bool IsUnix()
        {
            var isUnix = RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                || RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            return isUnix;
        }
        public static MemoryMetrics GetMemoryMetrics()
        {
            if (IsUnix())
            {
                return GetUnixMemoryMetrics();
            }
            return GetWindowsMemoryMetrics();
        }
        private static MemoryMetrics GetWindowsMemoryMetrics()
        {
            var output = "";

            var info = new ProcessStartInfo();
            info.FileName = "wmic";
            info.Arguments = "OS get FreePhysicalMemory,TotalVisibleMemorySize /Value";
            info.RedirectStandardOutput = true;

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }

            var lines = output.Trim().Split('\n');
            var freeMemoryParts = lines[0].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            var totalMemoryParts = lines[1].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            var metrics = new MemoryMetrics();
            metrics.Total = Math.Round(double.Parse(totalMemoryParts[1]) / 1024, 0);
            metrics.Free = Math.Round(double.Parse(freeMemoryParts[1]) / 1024, 0);
            metrics.Used = metrics.Total - metrics.Free;

            return metrics;
        }

        private static MemoryMetrics GetUnixMemoryMetrics()
        {
            var output = "";

            var info = new ProcessStartInfo("free -m");
            info.FileName = "/bin/bash";
            info.Arguments = "-c \"free -m\"";
            info.RedirectStandardOutput = true;

            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
            }

            var lines = output.Split('\n');
            var memory = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var metrics = new MemoryMetrics();
            metrics.Total = double.Parse(memory[1]);
            metrics.Used = double.Parse(memory[2]);
            metrics.Free = double.Parse(memory[3]);

            return metrics;
        }
    }

    public class MemoryMetrics
    {
        public double Total { get; set; }
        public double Used { get; set; }
        public double Free { get; set; }
    }
}
