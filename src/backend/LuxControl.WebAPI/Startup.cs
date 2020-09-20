using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using LuxControl.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LuxControl.WebAPI
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
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddDbContext<LuxControlContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("LuxControlContext"));
                options.EnableDetailedErrors();            
            });


            // services.AddSession();

            // services.AddTransient<LuxControl>(_ => new LuxControl(Configuration["ConnectionStrings:LuxControlContext"]));
            // services.AddDbContext<LuxControlContext>(options =>
            // options.UseSqlServer(Configuration.GetConnectionString("LuxControlContext"), x => x.MigrationsAssembly("LuxControl.Infrastructure")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.UseSession();
        }
    }
}
