using Microsoft.EntityFrameworkCore;
using MultiTenantSaaS.Application.Interfaces;
using MultiTenantSaaS.Domain.Entities;
using MultiTenantSaaS.InfraStructure.Data;

namespace MultiTenantSaaS.InfraStructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Add a new user asynchronously
        public async Task AddAsync(User user, CancellationToken ct = default)
        {
            await _db.Users.AddAsync(user, ct);
        }

        // Get user by unique identifier
        public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == id, ct);
        }

        // Get user by email (within specific tenant)
        public async Task<User?> GetByEmailAsync(Guid tenantId, string email, CancellationToken ct = default)
        {
            return await _db.Users
                .FirstOrDefaultAsync(u => u.TenantId == tenantId && u.Email == email, ct);
        }

        // Get all users belonging to a specific tenant
        public async Task<IEnumerable<User>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default)
        {
            return await _db.Users
                .Where(u => u.TenantId == tenantId)
                .ToListAsync(ct);
        }

        // Update an existing user entity
        public void Update(User user)
        {
            _db.Users.Update(user);
        }

        // Remove a user from the database
        public void Remove(User user)
        {
            _db.Users.Remove(user);
        }
    }
}
