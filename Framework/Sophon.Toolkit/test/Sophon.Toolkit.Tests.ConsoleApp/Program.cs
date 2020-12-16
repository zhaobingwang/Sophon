using System;

namespace Sophon.Toolkit.Tests.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var memoryMetrics = SystemUtil.GetMemoryMetrics();
            Console.WriteLine($"{memoryMetrics.Total}\t{memoryMetrics.Used}\t{memoryMetrics.Free}");
        }
    }
}
