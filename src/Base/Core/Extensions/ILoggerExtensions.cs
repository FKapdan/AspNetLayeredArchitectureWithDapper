using Core.Entities.General;
using Core.Entities.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CustomILoggerExtensions
    {
        private static IHttpContextAccessor httpContextAccessor;
        private static CoreSettings coreSettings;
        public static void Configure(IHttpContextAccessor HttpContextAccessor, CoreSettings CoreSettings)
        {
            httpContextAccessor = HttpContextAccessor;
            coreSettings = CoreSettings;
        }
        public static void LogSuccess<TReq, TResp>(this ILogger logger, LogLevel logLevel, TReq request, TResp response) where TReq : class where TResp : class
        {
            //if (httpContextAccessor.HttpContext != null)
            //{
            //    var ProjectName = Assembly.GetEntryAssembly()?.GetName().Name;
            //    string Message = $"{logLevel.ToString()}: {eventId.ToString()} - {categoryname} {formatter(state, exception)}";
            //    var LogData = new LogModel()
            //    {
            //        CreateDate = DateTime.Now,
            //        Method = categoryname,
            //        Message = logLevel == LogLevel.Information ? "Bilgi" : (exception?.Message ?? "Hata oluştu."),
            //        Details = Message,
            //        Ip = httpContextAccessor.HttpContext.GetHeaderValueByKey("ClientIp") ?? httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
            //        LogType = logLevel.ToString(),
            //        Request = "",
            //        Response = "",
            //        StatusCode = logLevel == LogLevel.Information ? 200 : 500,
            //        Token = httpContextAccessor.HttpContext.GetHeaderValueByKey("Authorization"),
            //        Url = httpContextAccessor.HttpContext?.GetRequestUrl(),
            //        TraceIdentifier = httpContextAccessor.HttpContext.TraceIdentifier,
            //        User = httpContextAccessor.HttpContext.User.Identity.Name,
            //    };

            //    if (coreSettings.LogEnv == LogEnv.File)
            //    {
            //        //File log
            //    }
            //    else if (coreSettings.LogEnv == LogEnv.Db)
            //    {
            //        //DB log
            //    }
            //    else if (coreSettings.LogEnv == LogEnv.Elastic)
            //    {
            //        //Elastich log
            //    }
            //    else
            //    {

            //    }
            //}
        }
    }
    public class ILoggerExtensions : ILogger
    {
        private readonly string categoryname;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly CoreSettings coreSettings;

        public ILoggerExtensions(
            string CategoryName,
            IHttpContextAccessor HttpContextAccessor,
            CoreSettings CoreSettings
            )
        {
            categoryname = CategoryName;
            httpContextAccessor = HttpContextAccessor;
            coreSettings = CoreSettings;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

        }
    }
}
