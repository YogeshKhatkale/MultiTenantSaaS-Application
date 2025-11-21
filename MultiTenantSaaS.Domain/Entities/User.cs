using MultiTenantSaaS.Domain.Common;
using System;


namespace MultiTenantSaaS.Domain.Entities
{
    public class User:BaseEntity
    {
     
        public string Email { get; private set; }
        public string FullName { get; private set; }

        protected User() { }
        public User(Guid tenantId,string email, string fullname) 
        {
            if (tenantId == Guid.Empty) throw new ArgumentException("TenantId is required ",nameof(tenantId));
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email is required ", nameof(email));
            if (string.IsNullOrEmpty(fullname)) throw new ArgumentException("FullName is required ", nameof(fullname));

            TenantId = tenantId;
            Email = email.Trim();
            FullName = fullname.Trim();
        }

        public void UpdateName(string newName)
        {
            FullName = newName;
            SetUpdated();
        }

    }
}
