using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Microsoft.Extensions.DependencyInjection {

    public static class SwaggerServiceExtensions {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services) {
            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Sport Stuff Internet Shop",
                    Version = "v1"
                });
                var securitySchema = new OpenApiSecurityScheme {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                o.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement {
                    { securitySchema, new[] { "Bearer" } }
                };
                o.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app) {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sport Stuff Internet Shop v1");
            });
            return app;
        }
    }
}
