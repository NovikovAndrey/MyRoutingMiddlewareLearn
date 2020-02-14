using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRoutingMiddleware
{
    public class AuthenticationMiddleware
    {
        private RequestDelegate requestDelegate;
        public AuthenticationMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 403;
                //await context.Response.WriteAsync("Access to hell denied");
            }
            else
            {
                await requestDelegate.Invoke(context);
            }
        }
    }
}
