using MultiTenantSaaS.Domain.Common;


namespace MultiTenantSaaS.Domain.Entities
{
    public class User:BaseEntity
    {
       public Guid TenantId { get;  set; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public User(Guid tenantId,string email, string fullname) 
        {
            TenantId = tenantId;
            Email = email;
            FullName = fullname;
        }

        public void UpdateName(string newName)
        {
            FullName = newName;
            SetUpdated();
        }

    }
}
