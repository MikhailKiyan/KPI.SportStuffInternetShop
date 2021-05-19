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
