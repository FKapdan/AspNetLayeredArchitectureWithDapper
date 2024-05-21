using Core.Abstracts;
using Entities;
using Entities.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.DI;

namespace Business.DI
{
    public static class BusinessDIOps
    {
        /// <summary>
        /// Business katmanındaki servisler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoryServices(configuration);
            services.AddTransient<LayerAbstractBase<DatabaseTableModel>, DatabaseTableModelService>();
            services.AddTransient<LayerAbstractBase<Users>, UsersService>();
            services.AddTransient<LayerAbstractBase<Assets>, AssetsService>();
        }
    }
}
