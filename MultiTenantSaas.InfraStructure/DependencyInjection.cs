using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantSaaS.Application.Interfaces;
using MultiTenantSaaS.InfraStructure.Data;
using MultiTenantSaaS.InfraStructure.Repositories;


namespace MultiTenantSaaS.InfraStructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // Configure the DbContext with SQL Server provider
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(
                config.GetConnectionString("DefaultConnection")
                
            ));
        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork , UnitOfWork >();
        return services;
    }
}



