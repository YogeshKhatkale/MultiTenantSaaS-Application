using Microsoft.EntityFrameworkCore;
using MultiTenantSaaS.Domain.Entities;
using MultiTenantSaaS.InfraStructure.Services;

namespace MultiTenantSaaS.InfraStructure.Data
{
    public  class ApplicationDbContext:DbContext
    {

        private readonly ITenantProvider? _tenantProvider;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ITenantProvider? tenantProvider = null) 
            : base(options) 
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();

        public DbSet<User> Users => Set<User>();
        public DbSet<Workspace> Workspaces => Set<Workspace>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<ActivityLog> ActivityLogs => Set<ActivityLog>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Multi-Tenant Global Filters (shared DB)
            Guid tenantId = _tenantProvider?.CurrentTenant?.Id ?? Guid.Empty;

            // Apply filter ONLY to tenant-scoped tables
            modelBuilder.Entity<User>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<Project>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<Workspace>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<Role>().HasQueryFilter(e => e.TenantId == tenantId);
            modelBuilder.Entity<ActivityLog>().HasQueryFilter(e => e.TenantId == tenantId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
