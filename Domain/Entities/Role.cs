namespace MultiTenentSaaS.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid TenantId { get; set; }
        public string Name { get; set; } = null;
        public string? PremissionsJson { get; set; }  // Store permissions as Json 

    }
}
