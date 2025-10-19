namespace MultiTenentSaaS.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkplaceId {  get; set; }
        public string Name { get; set; } = null;
        public string? Description { get; set; }

        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
    }
}
