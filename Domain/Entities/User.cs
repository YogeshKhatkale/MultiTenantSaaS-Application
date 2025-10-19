using MultiTenentSaaS.Domain.Common;


namespace MultiTenentSaaS.Domain.Entities
{
    public class User:BaseEntity
    {
       public Guid TenantId { get;  set; }
        public string EmailId { get; private set; }
        public string FullName { get; private set; }
        public User(Guid tenantId,string email, string fullname) 
        {
            TenantId = tenantId;
            EmailId = email;
            FullName = fullname;
        }

        public void UpdateName(string newName)
        {
            FullName = newName;
            SetUpdated();
        }

    }
}
