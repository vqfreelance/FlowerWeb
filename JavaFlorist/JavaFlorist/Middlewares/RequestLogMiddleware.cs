using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace JavaFlorist.Middlewares
{

    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string ip4 = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            string ip6 = httpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            string url = httpContext.Request.Path.ToString();
            Debug.WriteLine("ip4: " + ip4);
            Debug.WriteLine("ip6: " + ip6);
            Debug.WriteLine("url: " + url);
            return _next(httpContext);
        }
    }

    public static class RequestLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}
