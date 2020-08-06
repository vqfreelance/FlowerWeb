using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace JavaFlorist.Middlewares
{
    public class AdminMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.Path;
            if (url.HasValue && url.Value.StartsWith("/admin") && !url.Value.StartsWith("/admin/account"))
            {
                if (httpContext.Session.GetString("username") == null)
                {
                    httpContext.Response.Redirect("/admin/account");
                }
            }
            return _next(httpContext);
        }
    }

    public static class AdminMiddlewareExtensions
    {
        public static IApplicationBuilder UseAdminMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AdminMiddleware>();
        }
    }
}
