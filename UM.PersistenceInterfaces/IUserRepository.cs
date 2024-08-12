using UM.Domain;

namespace UM.PersistenceInterfaces;

public interface IUserRepository : IRepository<User, Guid>
{
    Task<List<string>> GetUserRolesAsync(Guid userId);
    Task AddUserRoleAsync(Guid userId, UserRole role);
    Task DeleteUserRoleAsync(Guid userId, string roleName);
    Task<List<User>> GetUsersWithSortAsync(int page, int pageSize, string? sortBy);
    Task<bool> CheckEmailExistsAsync(string email);
    Task<bool> CheckEmailExistsAsync(Guid userId, string email);
}
