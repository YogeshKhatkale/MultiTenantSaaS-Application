using AutoMapper;
using MultiTenantSaaS.Application.DTOs;
using MultiTenantSaaS.Application.Interfaces;
using MultiTenantSaaS.Domain.Entities;



namespace MultiTenantSaaS.Application.Services;
public class UserService : IUserServices
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UserService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto input, CancellationToken ct = default)
    {
        var user = new User(input.TenantId, input.Email, input.FullName);
        await _uow.Users.AddAsync(user, ct);
        await _uow.CommitAsync(ct);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        var user = await _uow.Users.GetByIdAsync(id, ct);
        return user is null ? null : _mapper.Map<UserDto>(user);
    }
}