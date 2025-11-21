using MultiTenantSaaS.Api.Infrastructure;
using MultiTenantSaaS.Application;
using MultiTenantSaaS.InfraStructure;
using MultiTenantSaaS.InfraStructure.Data;
using MultiTenantSaaS.InfraStructure.Services;
using Microsoft.EntityFrameworkCore;

namespace MultiTenantSaaS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // app layers

            builder.Services.AddInfrastructureServices(builder.Configuration);
            // extension from infra
            builder.Services.AddApplicationServices(); // extension from app 
            // Register tenant provider (scoped per request)
            builder.Services.AddScoped<ITenantProvider, TenantProvider>();

            // Register ApplicationDbContext with dynamic connection string per-request
            builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                // We still need a default connection (meta DB) to resolve tenants.
                // Use a "Master" connection from configuration for tenants table.
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var masterConn = configuration.GetConnectionString("Master"); // add in appsettings
                options.UseSqlServer(masterConn, sql => sql.EnableRetryOnFailure());
            });

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseTenantResolution();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
