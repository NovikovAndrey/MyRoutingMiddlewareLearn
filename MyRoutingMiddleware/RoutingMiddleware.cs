using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyRoutingMiddleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public RoutingMiddleware(RequestDelegate request)
        {
            requestDelegate = request;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path=="/index")
            {
                await context.Response.WriteAsync("Home page");
            }
            else if (path=="/about")
            {
                await context.Response.WriteAsync("About ");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }

    }
}
