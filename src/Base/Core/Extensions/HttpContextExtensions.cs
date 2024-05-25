using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Core.Extensions
{
    internal static class HttpContextExtensions
    {
        public static string? GetRequestUrl(this HttpContext httpContext)
        {
            if (httpContext == null) return null;
            return $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}{httpContext.Request.PathBase}{httpContext.Request.Path}";
        }
        public static string? GetHeaderValueByKey(this HttpContext httpContext, string HeaderKey)
        {
            if (httpContext == null) return null;
            httpContext.Request.Headers.TryGetValue(HeaderKey, out StringValues headervalue);
            return headervalue.FirstOrDefault();
        }
        public static string? GetRequestMethod(this HttpContext httpContext)
        {
            if (httpContext == null) return null;
            return httpContext.Request.Method;
        }
        public static string? GetRequestIp(this HttpContext httpContext)
        {
            if (httpContext == null) return null;
            return httpContext.Connection.RemoteIpAddress.ToString();
        }
        public static int GetResponseStatusCode(this HttpContext httpContext)
        {
            if (httpContext == null) return 520;
            return httpContext.Response.StatusCode;
        }
        public static string GetTraceInf(this HttpContext httpContext)
        {
            if (httpContext == null) return null;
            return httpContext.TraceIdentifier;
        }
        public static string GetUser(this HttpContext httpContext)
        {
            if (httpContext == null) return null;
            return httpContext.User.Identity.Name;
        }
    }
}
