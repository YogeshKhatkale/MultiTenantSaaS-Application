namespace MultiTenantSaaS.Application.DTOs
{
    public record UserDto(Guid Id, Guid TenantId, string Email, string FullName, DateTime CreatedAt);
}
