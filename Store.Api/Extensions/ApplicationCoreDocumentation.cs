

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Api.Extensions
{
    public static class ApplicationCoreDocumentation
    {
        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
           {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
           }));
            return services;
        }

        public static IApplicationBuilder UseCoreDocumentation(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
            return app;
        }
    }
}
