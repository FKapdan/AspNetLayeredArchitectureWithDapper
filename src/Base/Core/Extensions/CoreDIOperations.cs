using Core.Entities;
using Core.Entities.Settings;
using Core.Services;
using Core.Services.Abstracts;
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
                    else
                    {
                        Configuration[confitem.Key] = confitem.Value;
                    }
                }
            }
            else
            {
                Configuration = coreconfinfo;
            }


            services.Configure<CoreSettings>(Configuration.GetSection(nameof(CoreSettings)));
            JsonSerializerExtensions.Configure();
            CustomILoggerExtensions.Configure(services.BuildServiceProvider(), Configuration);
            return services;
        }
        public static IServiceCollection AddCoreOperations(this IServiceCollection services, Action<CoreDIConfs> optionsBuilder)
        {
            var options = new CoreDIConfs();
            optionsBuilder(options);
            if (options.IsAddJwtServices)
            {
                services.AddSingleton<IJwtServices, JwtServices>();
            }
            if (options.IsAddJwtServices)
            {
                services.AddSingleton<ILogService, FileLogService>();
            }
            return services;
        }
    }
}
