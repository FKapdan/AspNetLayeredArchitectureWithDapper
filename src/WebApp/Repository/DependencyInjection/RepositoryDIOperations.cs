using Entities.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Repository.Interfaces;

namespace Repository.DependencyInjection
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
            services.AddTransient<RepositoryBase<DatabaseTableModelDto>, DatabaseTableModelRepository>();
            services.AddTransient<RepositoryBase<UsersDto>, UsersRepository>();
            services.AddTransient<RepositoryBase<AssetsDto>, AssetsRepository>();
        }
    }
}
