using System.Threading;
using System.Threading.Tasks;
using MultiTenantSaaS.Application.Interfaces;
using MultiTenantSaaS.InfraStructure.Data;

namespace MultiTenantSaaS.InfraStructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IUserRepository? _userRepository;  // Lazy initialization

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Expose UserRepository instance
        public IUserRepository Users
        {
            get
            {
                return _userRepository ??= new UserRepository(_dbContext);
            }
        }

        // Commit all pending changes to the database
        public async Task<int> CommitAsync(CancellationToken ct = default)
        {
            return await _dbContext.SaveChangesAsync(ct);
        }

        // Optional: Implement IDisposable pattern
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

