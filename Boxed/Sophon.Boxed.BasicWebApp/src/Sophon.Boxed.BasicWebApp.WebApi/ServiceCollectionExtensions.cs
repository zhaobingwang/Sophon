using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Boxed.BasicWebApp.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.JwtSetting));

            return services;
        }
    }
}
