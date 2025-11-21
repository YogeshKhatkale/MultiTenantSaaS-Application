using MultiTenantSaaS.Domain.Entities;

namespace MultiTenantSaaS.InfraStructure.Services
{
    public interface ITenantProvider
    {
        Tenant? CurrentTenant { get; }
        void SetCurrentTenant(Tenant tenant);
    }
}