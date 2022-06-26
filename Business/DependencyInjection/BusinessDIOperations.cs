using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities;
using AspNetLayeredArchitectureWithDapper.Entities.Business;
using AspNetLayeredArchitectureWithDapper.Repository.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetLayeredArchitectureWithDapper.Business.DependencyInjection
{
    public static class BusinessDIOperations
    {
        /// <summary>
        /// Business katmanındaki servisler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositoryServices(configuration);
            services.AddTransient<IBusinessServiceBase<DatabaseTableModel>, DatabaseTableModelService>();
            services.AddTransient<IBusinessServiceBase<Users>, UsersService>();
            services.AddTransient<IBusinessServiceBase<Assets>, AssetsService>();
        }
    }
}
