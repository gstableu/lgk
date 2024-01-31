using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace LGK.Library
{
    internal class MyCustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public MyCustomMiddleware(RequestDelegate next, IServiceProvider _serviceProvider)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogger logger)
        {
            //var logger = _serviceProvider.GetService<ILogger>();
            //logger.LogInformation("Test middleware");
            await _next(context);
        }
    }
}