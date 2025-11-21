using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MultiTenantSaaS.Domain.Entities;
using MultiTenantSaaS.InfraStructure.Data; // adjust namespace if necessary
using MultiTenantSaaS.InfraStructure.Services; 
using System.Threading.Tasks;

namespace MultiTenantSaaS.Api.Infrastructure
{
    public class TenantResolutionMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantResolutionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider, ApplicationDbContext dbContext)
        {
            // 1. Resolve tenant by header, subdomain, or Host
            // Priority: X-Tenant header -> subdomain (tenant.example.com) -> host exact match
            string? tenantIdentifier = null;
            if (context.Request.Headers.TryGetValue("X-Tenant", out var tHeader) && !string.IsNullOrWhiteSpace(tHeader))
            {
                tenantIdentifier = tHeader.ToString();
            }
            else
            {
                var host = context.Request.Host.Host; // e.g. tenant1.example.com
                // simple heuristic: if host contains subdomain
                var parts = host.Split('.');
                if (parts.Length >= 3)
                {
                    tenantIdentifier = parts[0]; // subdomain
                }
                else
                {
                    tenantIdentifier = host; // or full host
                }
            }

            Domain.Entities.Tenant? tenant = null;
            if (!string.IsNullOrWhiteSpace(tenantIdentifier))
            {
                // first try domain match then name
                tenant = await dbContext.Tenants.FirstOrDefaultAsync(t =>
                    t.Domain != null && t.Domain.ToLower() == tenantIdentifier.ToLower()
                    || t.Name.ToLower() == tenantIdentifier.ToLower());
            }

            if (tenant is null)
            {
                // Optionally: set a default tenant or short-circuit with 404
                // For safety we can continue as no-tenant (but many actions should require tenant)
                // Uncomment to reject unknown tenant:
                // context.Response.StatusCode = 400; await context.Response.WriteAsync("Tenant not found"); return;
            }
            else
            {
                tenantProvider.SetCurrentTenant(tenant);
            }

            await _next(context);
        }
    }

    // extension for easy registration
    public static class TenantResolutionMiddlewareExtensions
    {
        public static IApplicationBuilder UseTenantResolution(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TenantResolutionMiddleware>();
        }
    }
}
