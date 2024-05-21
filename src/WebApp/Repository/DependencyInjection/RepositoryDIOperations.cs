using Core.Abstracts;
using Entities.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

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
            services.AddTransient<LayerAbstractBase<DatabaseTableModelDto>, DatabaseTableModelRepository>();
            services.AddTransient<LayerAbstractBase<UsersDto>, UsersRepository>();
            services.AddTransient<LayerAbstractBase<AssetsDto>, AssetsRepository>();
        }
    }
}
