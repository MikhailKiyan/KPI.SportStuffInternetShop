using KPI.SportStuffInternetShop.BusinessServices;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Services.Contracts;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPI.SportStuffInternetShop.API {

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseSqlServer(
                    this.Configuration.GetConnectionString("MainDb"),
                    b => b.MigrationsAssembly("KPI.SportStuffInternetShop.Data")
                          .MigrationsHistoryTable("MigrationsHistory", "EF")
                )
            );
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IGenericRepository<Domains.Product, Guid>, GenericRepository<Domains.Product, Guid>>();
            services.AddScoped<IGenericRepository<Domains.ProductBrand, Guid>, GenericRepository<Domains.ProductBrand, Guid>>();
            services.AddScoped<IGenericRepository<Domains.ProductType, Guid>, GenericRepository<Domains.ProductType, Guid>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
                IApplicationBuilder app,
                IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
