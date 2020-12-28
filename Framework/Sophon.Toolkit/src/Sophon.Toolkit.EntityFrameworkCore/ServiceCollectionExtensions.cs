using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sophon.Toolkit.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();

            return services;
        }
    }
}
