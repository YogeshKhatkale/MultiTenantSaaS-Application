
using MultiTenantSaaS.Domain.Entities;
namespace MultiTenantSaaS.Application.Interfaces;
public interface IUnitOfWork
{
    IUserRepository Users { get; }
    Task<int> CommitAsync(CancellationToken ct = default);
}