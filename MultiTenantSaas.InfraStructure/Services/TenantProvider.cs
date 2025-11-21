using MultiTenantSaaS.Domain.Entities;

namespace MultiTenantSaaS.InfraStructure.Services
{
    // MUST be public so API project can use it
    public class TenantProvider : ITenantProvider
    {
        private Tenant? _tenant;

        public Tenant? CurrentTenant => _tenant;

        public void SetCurrentTenant(Tenant tenant)
        {
            _tenant = tenant;
        }
    }
}
