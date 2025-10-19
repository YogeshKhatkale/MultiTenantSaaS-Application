using MultiTenantSaaS.Domain.Entities;

namespace MultiTenantSaaS.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user , CancellationToken ct = default);

        Task<User?> GetByIdAsync(Guid id , CancellationToken ct = default);

        Task<User?> GetByEmailAsync(Guid tenantId ,string email , CancellationToken ct = default);

        Task <IEnumerable<User>>
            GetAllByTenantAsync(Guid tenantId , CancellationToken ct = default);

        void Update(User user);
        void Remove(User user);
    }
}
