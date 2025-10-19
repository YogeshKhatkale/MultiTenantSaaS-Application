using Microsoft.Extensions.DependencyInjection;
using MultiTenantSaaS.Application.Interfaces;
using MultiTenantSaaS.Application.Services;

namespace MultiTenantSaaS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register all Application-layer services here
            services.AddScoped<IUserServices, UserService>();

            // Add AutoMapper or MediatR if you use them
            // Example:
            // services.AddAutoMapper(typeof(MappingProfile));
            // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    }
}
