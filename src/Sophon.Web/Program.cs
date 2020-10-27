using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Sophon.Infrastructure.Data;

namespace Sophon.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Debug()
            //    .WriteTo.SQLite(@"c:\LocalDB\sophon.db", "logs")
            //    .CreateLogger();

            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var dbContext = service.GetRequiredService<SophonDbContext>();
                var logger = service.GetRequiredService<ILogger<Program>>();
                try
                {
                    SeedData.SeedAsync(service).Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the db");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog((context, configuration) =>
                    {
                        configuration.MinimumLevel.Information()
                        // 日志调用类命名空间如果以 Microsoft 开头，覆盖日志输出最小级别为 Error
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                        .MinimumLevel.Override("System", LogEventLevel.Error)
                        .Enrich.FromLogContext()
                        // 配置日志输出到控制台
                        .WriteTo.Console()
                        .WriteTo.SQLite(@"c:\LocalDB\sophon.db", "logs");
                        // 创建 logger
                        //.CreateLogger();
                    });
                });
    }
}
