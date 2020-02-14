using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRoutingMiddleware
{
    public class ErrorHandlingMiddleware
    {
        private RequestDelegate requestDelegate;
        public ErrorHandlingMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await requestDelegate.Invoke(context);
            if (context.Response.StatusCode==403)
            {
                await context.Response.WriteAsync("You do not have access");
            }
            else if (context.Response.StatusCode==404)
            {
                await context.Response.WriteAsync("Page not found");
            }
        }
    }
}
