using Core.Entities.Jwt;
using Core.Entities.Settings;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Providers
{
    public class CoreILoggerProvider : ILoggerProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly CoreSettings _coreSettings;
        public CoreILoggerProvider(
            IServiceProvider serviceProvider,
            IConfiguration configuration
            )
        {
            _coreSettings = configuration.GetSection("CoreSettings").Get<CoreSettings>();
            _contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ILoggerExtensions(categoryName, _contextAccessor, _coreSettings);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
