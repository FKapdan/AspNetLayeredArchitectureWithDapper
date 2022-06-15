using AspNetLayeredArchitectureWithDapper.Business.Interfaces;
using AspNetLayeredArchitectureWithDapper.Entities;
using AspNetLayeredArchitectureWithDapper.Repository.DependencyInjection;
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
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddRepositoryServices();
            services.AddTransient<IBusinessServiceBase<DatabaseTableModel>, DatabaseTableModelService>();
        }
    }
}
