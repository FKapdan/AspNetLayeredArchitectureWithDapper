using Core.Entities.General;
using Core.Entities.Settings;
using Core.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Core.Extensions
{
    public static class CustomILoggerExtensions
    {
        private static IHttpContextAccessor httpContextAccessor;
        private static CoreSettings coreSettings;
        private static ILogService logService;
        public static void Configure(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            logService = serviceProvider.GetRequiredService<ILogService>();
            coreSettings = configuration.Get<CoreSettings>();
        }
        /// <summary>
        /// Gönderilen istek ve dönüş modelleri ile log işlemi yapar
        /// </summary>
        /// <typeparam name="TReq"></typeparam>
        /// <typeparam name="TResp"></typeparam>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="request"></param>
        /// <param name="response"></param>
        /// <param name="Message"></param>
        public static void Log<TReq, TResp>(this ILogger logger, LogLevel logLevel, TReq request, TResp response, string? Message = "") where TReq : class where TResp : class
        {
            if (httpContextAccessor.HttpContext != null)
            {
                var ProjectName = Assembly.GetEntryAssembly()?.GetName().Name;
                var LogData = new LogModel()
                {
                    RequestType = httpContextAccessor.HttpContext.GetRequestMethod(),
                    CreateDate = DateTime.Now,
                    Method = httpContextAccessor.HttpContext?.GetRequestUrl(),
                    Message = Message,
                    Details = Message,
                    Ip = httpContextAccessor.HttpContext.GetHeaderValueByKey("ClientIp") ?? httpContextAccessor.HttpContext.GetRequestIp(),
                    LogType = logLevel.ToString(),
                    Request = JsonSerializerExtensions.SerializeCore(request),
                    Response = JsonSerializerExtensions.SerializeCore(response),
                    StatusCode = httpContextAccessor.HttpContext.GetResponseStatusCode(),
                    Token = httpContextAccessor.HttpContext.GetHeaderValueByKey("Authorization"),
                    Url = httpContextAccessor.HttpContext?.GetRequestUrl(),
                    TraceIdentifier = httpContextAccessor.HttpContext.GetTraceInf(),
                    User = httpContextAccessor.HttpContext.GetUser()
                };
                Log(LogData);
            }
        }
        /// <summary>
        /// Gönderilen mesaj bilgisi ile log işlemi yapar
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="logLevel"></param>
        /// <param name="Message"></param>
        public static void Log(this ILogger logger, LogLevel logLevel, string? Message = "")
        {
            if (httpContextAccessor.HttpContext != null)
            {
                var ProjectName = Assembly.GetEntryAssembly()?.GetName().Name;
                var LogData = new LogModel()
                {
                    RequestType = httpContextAccessor.HttpContext.GetRequestMethod(),
                    CreateDate = DateTime.Now,
                    Method = httpContextAccessor.HttpContext?.GetRequestUrl(),
                    Message = Message,
                    Details = Message,
                    Ip = httpContextAccessor.HttpContext.GetHeaderValueByKey("ClientIp") ?? httpContextAccessor.HttpContext.GetRequestIp(),
                    LogType = logLevel.ToString(),
                    StatusCode = httpContextAccessor.HttpContext.GetResponseStatusCode(),
                    Token = httpContextAccessor.HttpContext.GetHeaderValueByKey("Authorization"),
                    Url = httpContextAccessor.HttpContext?.GetRequestUrl(),
                    TraceIdentifier = httpContextAccessor.HttpContext.GetTraceInf(),
                    User = httpContextAccessor.HttpContext.GetUser()
                };
                Log(LogData);
            }
        }

        private static void Log(LogModel LogData)
        {
            if (coreSettings.LogEnv == LogEnv.File)
            {
                logService.Log(LogData);
            }
            else if (coreSettings.LogEnv == LogEnv.Db)
            {
                //DB log
            }
            else if (coreSettings.LogEnv == LogEnv.Elastic)
            {
                //Elastich log
            }
            else
            {

            }
        }
    }
}
