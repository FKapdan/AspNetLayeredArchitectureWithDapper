using Core.Entities;
using Core.Entities.Settings;
using Core.Utilities;
using Core.Utilities.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class CoreDIOperations
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration Configuration)
        {
            IConfiguration coreconfinfo = new ConfigurationBuilder().AddJsonFile("appsettings.core.json", optional: true, reloadOnChange: true).Build();

            if (Configuration != null)
            {
                foreach (var confitem in coreconfinfo.AsEnumerable())
                {
                    if (Configuration.AsEnumerable().Any(x => x.Key == confitem.Key))
                    {
                        Configuration[confitem.Key] = confitem.Value;
                    }
                    else {
                        Configuration[confitem.Key] = confitem.Value;
                    }
                }
            }
            else
            {
                Configuration = coreconfinfo;
            }
            services.Configure<CoreSettings>(Configuration.GetSection(nameof(CoreSettings)));
            return services;
        }
        public static IServiceCollection AddCoreOperations(this IServiceCollection services, Action<CoreDIConfs> optionsBuilder)
        {
            var options = new CoreDIConfs();
            optionsBuilder(options);
            if (options.IsAddJwtHelper)
            {
                services.AddSingleton<IJwtHelpler, JwtHelpler>();
            }
            return services;
        }
    }
}
