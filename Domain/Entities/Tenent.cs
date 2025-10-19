using MultiTenentSaaS.Domain.Common;

namespace MultiTenentSaaS.Domain.Entities
{
    public class Tenent:BaseEntity
    {
      public string Name { get; private set; }
        public string Domain {  get; private set; } = string.Empty;
        public Tenent(string name, string domain)
        {
            Name = name;
            Domain = domain;
        }

        // Example Behaviour

        public void Rename(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Tenant name required !");
            Name = newName;
            SetUpdated();
        }
    }
}
