namespace MultiTenantSaaS.Domain.Entities
{
    public class Workspace
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public Guid TenantId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Project> Projects { get; set; }= new List<Project>();
    }
}
