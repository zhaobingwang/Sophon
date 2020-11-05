using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Sophon.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace Sophon.Web.Extensions
{
    public static class DependenceExtension
    {
        public static void AddSophonService(this IServiceCollection services)
        {
            var defaultAssemblyNames = DependencyContext.Default.GetDefaultAssemblyNames().Where(x => x.FullName.Contains("Sophon.")).ToList();
            var assemblies = defaultAssemblyNames.SelectMany(a => a.GetTypeOfISerice()).ToList();

            assemblies.ForEach(assembliy =>
            {
                services.AddScoped(assembliy);
            });
        }

        private static List<Type> GetTypeOfISerice(this AssemblyName assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName).ExportedTypes.Where(b => b.GetInterfaces().Contains(typeof(ISophonAutoDependence))).ToList();
        }
    }
}
