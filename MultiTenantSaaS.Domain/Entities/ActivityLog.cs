namespace MultiTenantSaaS.Domain.Entities
{
    public class ActivityLog
    {

        public Guid Id { get; set; }= Guid.NewGuid();
        public Guid TenantId {  get; set; }
        public Guid? UserId { get; set; }
        public Guid? WorkplaceId { get; set; }
        public Guid? ProjectId { get; set; }
        public string Action { get; set; } = null;
        public string? Details { get; set; }
        public DateTime Timestamp { get; set; }= DateTime.Now;
    }
}
