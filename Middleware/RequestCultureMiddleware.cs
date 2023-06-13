using Microsoft.EntityFrameworkCore;
using MinhasFinancas.Domain;
using MinhasFinancas.Middleware;
using System.Globalization;
namespace MinhasFinancas.Middleware

{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string RouteAcessed = context.Request.Path;
            Console.WriteLine($"{RouteAcessed} - {context.Request.Method} - {context.Request.Protocol}");

            //if (RouteAcessed == "/api/user")
            //{
                await _next(context);
        }
    }
}

public static class RequestCultureMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestCulture(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestCultureMiddleware>();
    }
}
