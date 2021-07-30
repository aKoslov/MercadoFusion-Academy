using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.DapperDA;
using Tienda.Interfaces;
using Tienda.Logic;

namespace TiendaWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Program.NewSession(new UserLogic());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(options =>
            {
                //add_header 'Access-Control-Allow-Origin' 'http://localhost:4200' always;

                    options.AddPolicy("CorsPolicy", builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((Host) => true)
                        .AllowCredentials();
                    });

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TiendaWeb", Version = "v1" });
                
            });
          
            services.AddScoped<IProductLogic, ProductLogic>();
            services.AddScoped<IUserLogic, UserLogic>();
            //services.AddScoped<IUserLogic>(s => new DapperDataAccess("Default"));
            //services.AddScoped<IUsersLogic>(s => new DataHashing());
            services.AddScoped<IProductsCategoryLogic, ProductsCategoryLogic>();
            //services.AddScoped<IProductsCategoryLogic>(s => new DapperDataAccess("Default"));
            services.AddScoped<IOrderLogic, OrderLogic>();
            //services.AddScoped<IOrderLogic>(s => new DapperDataAccess("Default"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TiendaWeb v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
