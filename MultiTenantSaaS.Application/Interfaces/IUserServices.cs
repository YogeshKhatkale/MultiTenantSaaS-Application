using MultiTenantSaaS.Application.DTOs;

namespace MultiTenantSaaS.Application.Interfaces
{
    public interface IUserServices
    {
        Task<UserDto> CreateAsync(CreateUserDto input, CancellationToken ct = default);
        Task<UserDto?> GetByIdAsync(Guid id, CancellationToken ct = default);

    }
}
