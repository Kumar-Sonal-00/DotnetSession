using Microsoft.Extensions.DependencyInjection;
using PBBusinessLayerLib;
using PBDataAccessLayerLib;
using PBRepositoryLayerLib;

namespace ContactDependencyLib
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection RegisterDependencyComponents(this IServiceCollection services)
        {
            services.AddScoped<IContactBusinessLayer,ContactBusinessLayer>();
            services.AddScoped<IContactRepository,ContactRepository>();
            //services.AddScoped<IContactDataAccess,ContactDataAccess>();
            services.AddScoped<IContactDataAccess, AdoDisconnected>();
            return services;
        }
    }
}
