

namespace MultiTenantSaaS.Application.DTOs
{
    

        public record CreateUserDto(Guid TenentId,string Email,String FullName);
    
}
