using UM.Domain;
using UM.Services.DTOs;

namespace UM.Services.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(Guid id);
    Task DeleteUserAsync(Guid id);
    Task<User> CreateUserAsync(CreateUserDto userDto);
    Task<User> UpdateUserAsync(Guid id, UpdateUserDto userDto);

    Task<List<string>> GetUserRolesAsync(Guid userId);
    Task AddUserRoleAsync(Guid userId, string roleName);
    Task DeleteUserRoleAsync(Guid userId, string roleName);
    Task<List<User>> GetUsersWithSortAsync(int page, int pageSize, string? sortBy);
}
