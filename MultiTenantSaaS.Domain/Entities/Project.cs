using MultiTenantSaaS.Domain.Common;
using System;
namespace MultiTenantSaaS.Domain.Entities
{
    public class Project: BaseEntity
    {
        public Guid WorkspaceId { get;private set; } 
       
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; set; }

        public string Status { get; set; } = "Active";
       
        protected Project() { } 

        public Project( Guid workspaceId, string name, string? description = null)
        {
            if (workspaceId == Guid.Empty) throw new ArgumentException("WorkspaceId is required ", nameof(workspaceId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Project name is required ", nameof(name));
   
            WorkspaceId = workspaceId;
            Name = name.Trim();
            Description = description?.Trim();
        }

        // Behaviour methods

        public void UpdateName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentException("Project name is required ", nameof(newName));
            Name = newName.Trim();
            SetUpdated();
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription?.Trim();
            SetUpdated();
        }

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrEmpty(newStatus)) throw new ArgumentException("Project status is required ", nameof(newStatus));
            Status = newStatus.Trim();
            SetUpdated();
        }
    }
}
