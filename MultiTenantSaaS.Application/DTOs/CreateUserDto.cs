

namespace MultiTenantSaaS.Application.DTOs
{


    public record CreateUserDto(Guid TenantId, string Email, String FullName);

}
