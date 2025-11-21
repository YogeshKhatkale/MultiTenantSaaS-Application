using MultiTenantSaaS.Domain.Common;

namespace MultiTenantSaaS.Domain.Entities
{
    public class Tenant:BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string Domain {  get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;


        public Tenant(string name, string domain)
        {
            Name = name;
            Domain = domain;
        }

        // Example Behaviour

        public void Rename(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Tenant name required !");
            Name = newName;
            
        }
    }
}
