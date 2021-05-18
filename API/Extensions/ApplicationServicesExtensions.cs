using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ApplicationServicesExtensions {
        public static IServiceCollection AddApplicationServices(
                this IServiceCollection services,
                IConfiguration configuration) {



            return services;
        }
    }
}
