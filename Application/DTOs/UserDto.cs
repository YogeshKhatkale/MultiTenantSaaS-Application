
namespace MultiTenentSaaS.Application.DTOs
{
  public record UserDto(Guid Id, Guid TenentId,string Email, string FullName, DateTime CreatedAt );
}
