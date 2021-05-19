using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using KPI.SportStuffInternetShop.BusinessServices;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Services.Contracts;
using KPI.SportStuffInternetShop.BusinessServices.MappingProfiles;
using KPI.SportStuffInternetShop.API.Middleware;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using Microsoft.OpenApi.Models;

namespace KPI.SportStuffInternetShop.API {

    public class Startup {
        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper(typeof(ProducMappingProfiles));
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseSqlServer(
                    this.Configuration.GetConnectionString("MainDb"),
                    b => b.MigrationsAssembly("KPI.SportStuffInternetShop.Data")
                          .MigrationsHistoryTable("MigrationsHistory", "EF")));
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actionContext => {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToArray();
                    var errorResponse = new ApiValidationError {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });
            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Sport Stuff Internet Shop",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
                IApplicationBuilder app,
                IWebHostEnvironment env) {

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sport Stuff Internet Shop v1");
            });
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
