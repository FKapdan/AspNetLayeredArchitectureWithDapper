using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return headervalue.ToString();
        }
    }
}
