using Microsoft.Extensions.DependencyInjection;
using Store.Core;
using Store.Core.Services;
using Store.Data;
using Store.Services;

namespace Store.Api.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}