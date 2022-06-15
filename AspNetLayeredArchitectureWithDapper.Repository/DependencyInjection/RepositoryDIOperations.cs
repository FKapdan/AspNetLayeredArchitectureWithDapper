using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetLayeredArchitectureWithDapper.Repository.DependencyInjection
{
    public static class RepositoryDIOperations
    {
        /// <summary>
        /// Repository katmanındaki servisler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<DatabaseTableModelDto>, DatabaseTableModelRepository>();
        }
    }
}
