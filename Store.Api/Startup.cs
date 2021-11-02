using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Api.Extensions;
using Store.Api.Mapping;
using Store.Api.Middleware;
using Store.Data;

namespace Store.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Store.Data")));
            services.AddApplicationServices();
            services.AddSwaggerApplicationServices();
            services.AddCoreApplicationServices();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExeptionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseStatusCodePagesWithReExecute("errors/{0}");


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();
            
            app.UseCoreDocumentation();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

        }
    }
}
