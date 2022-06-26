using AspNetLayeredArchitectureWithDapper.Entities.Repository;
using AspNetLayeredArchitectureWithDapper.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace AspNetLayeredArchitectureWithDapper.Repository.DependencyInjection
{
    public static class RepositoryDIOperations
    {
        /// <summary>
        /// Repository katmanındaki servisler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IRepository<DatabaseTableModelDto>, DatabaseTableModelRepository>();
            services.AddTransient<IRepository<UsersDto>, UsersRepository>();
            services.AddTransient<IRepository<AssetsDto>, AssetsRepository>();
        }
    }
}
