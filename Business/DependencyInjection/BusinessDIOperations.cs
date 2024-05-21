using Business.Interfaces;
using Entities;
using Entities.Business;
using Repository.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyInjection
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
