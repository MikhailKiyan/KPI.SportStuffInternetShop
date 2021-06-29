using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using KPI.SportStuffInternetShop.Contracts.Services;
using KPI.SportStuffInternetShop.Data;
using KPI.SportStuffInternetShop.Services.Contracts;
using KPI.SportStuffInternetShop.BusinessServices;
using KPI.SportStuffInternetShop.API.ErrorResponseModels;
using StackExchange.Redis;
using KPI.SportStuffInternetShop.Domains.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KPI.SportStuffInternetShop.BusinessServices.Payment;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ApplicationServicesExtensions {
        public static IServiceCollection AddApplicationServices(
                this IServiceCollection services,
                IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseSqlServer(
                    configuration.GetConnectionString("MainDb"),
                    b => b.MigrationsAssembly("KPI.SportStuffInternetShop.Data")
                          .MigrationsHistoryTable("MigrationsHistory", "EF")));
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IBasketService, BasketService>();
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

            var builder = services.AddIdentityCore<User>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.AddSignInManager<SignInManager<User>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"])),
                        ValidIssuer = configuration["Token:Issuer"],
                        ValidateIssuer = true,
                        // ValidAudience = configuration["Token:Audience"],
                        // ValidateAudience = true
                        ValidateAudience = false
                    };
                });

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
