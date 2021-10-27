using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Api.Errors;

namespace Store.Api.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ILogger<ExeptionMiddleware> _logger { get; }
        private readonly IHostEnvironment env;
        public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger, IHostEnvironment env)
        {
            this.env = env;
            this._logger = logger;
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = env.IsDevelopment() ? new ApiExeption((int)HttpStatusCode.InternalServerError, ex.Message,
                ex.StackTrace.ToString()) :
                new ApiExeption((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response,options);

                await context.Response.WriteAsync(json);
            }
        }

    }
}