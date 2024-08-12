using Microsoft.EntityFrameworkCore;
using System.Data;
using UM.Domain;
using UM.Domain.Exceptions;
using UM.PersistenceInterfaces;

namespace UM.PersistenceImplementations;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users
                .Include(m => m.Roles)
                .ToListAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.Include(m => m.Roles)
                .SingleOrDefaultAsync(m => m.Id.Equals(id))
                 ?? throw new NotFoundException($"User: {id} not found.");
    }

    public async Task<User> CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(Guid id)
    {
        var userToDelete = await GetByIdAsync(id);
        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<List<string>> GetUserRolesAsync(Guid userId)
    {
        var user = await GetByIdAsync(userId);
        return user.Roles.Select(r => r.Name.ToString()).ToList();
    }

    public async Task AddUserRoleAsync(Guid userId, UserRole role)
    {
        var user = await GetByIdAsync(userId);

        if (user.Roles!.Exists(x => x.Name == role))
            throw new RoleAlreadyExistsException(role.ToString(), nameof(User));

        var roleToAdd = new Role { Name = role };

        user.Roles.Add(roleToAdd);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserRoleAsync(Guid userId, string roleName)
    {
        var user = await GetByIdAsync(userId);
        var roleToDelete = user.Roles.Where(r => r.Name.ToString() == roleName).ToList();
        foreach (var role in roleToDelete)
        {
            user.Roles.Remove(role);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetUsersWithSortAsync(int page, int pageSize, string? sortBy)
    {
        var query = _context.Users.Include(u => u.Roles).AsQueryable();


        if (!string.IsNullOrEmpty(sortBy))
        {
            switch (sortBy.ToLower())
            {
                case "name":
                    query = query.OrderBy(u => u.Name);
                    break;
                case "age":
                    query = query.OrderBy(u => u.Age);
                    break;
                case "email":
                    query = query.OrderBy(u => u.Email);
                    break;
                case "role":
                    query = query.OrderBy(u => u.Roles!.Count);
                    break;
                default:
                    throw new ArgumentException("Non-existent parameter");
            }
        }

        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return await query.ToListAsync();
    }

    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> CheckEmailExistsAsync(Guid userId, string email)
    {
        return await _context.Users.AnyAsync(u => u.Id != userId && u.Email == email);
    }
}
