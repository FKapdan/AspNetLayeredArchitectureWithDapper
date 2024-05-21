using Core.Abstracts;
using Entities.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DI
{
    public static class RepositoryDIOps
    {
        /// <summary>
        /// Repository katmanındaki servisler
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MySqlConnection>(_ => new MySqlConnection(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddSingleton<LayerAbstractBase<DatabaseTableModelDto>, DatabaseTableModelRepository>();
            services.AddSingleton<LayerAbstractBase<UsersDto>, UsersRepository>();
            services.AddSingleton<LayerAbstractBase<AssetsDto>, AssetsRepository>();
        }
    }
}
