using AutoMapper;
using UM.Domain;
using UM.Domain.Exceptions;
using UM.PersistenceInterfaces;
using UM.Services.Converters;
using UM.Services.DTOs;
using UM.Services.Interfaces;

namespace UM.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _userRepository = repository;
        _mapper = mapper;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateUserAsync(CreateUserDto userDto)
    {
        if (await _userRepository.CheckEmailExistsAsync(userDto.Email))
            throw new EmailAlreadyExistsException(userDto.Email.ToString());

        var user = _mapper.Map<User>(userDto);
        await _userRepository.CreateAsync(user);
        user = await GetUserByIdAsync(user.Id);
        return user;
    }

    public async Task<User> UpdateUserAsync(Guid id, UpdateUserDto userDto)
    {
        var existingUser = await GetUserByIdAsync(id);

        if (await _userRepository.CheckEmailExistsAsync(id, userDto.Email))
            throw new EmailAlreadyExistsException(userDto.Email.ToString());

        existingUser.Name = userDto.Name;
        existingUser.Age = userDto.Age;
        existingUser.Email = userDto.Email;

        return await _userRepository.UpdateAsync(existingUser);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteAsync(id);
    }

    public async Task<List<string>> GetUserRolesAsync(Guid userId)
    {
        return await _userRepository.GetUserRolesAsync(userId);
    }

    public async Task AddUserRoleAsync(Guid userId, string roleName)
    {
        if (!RoleConverter.TryConvertToEnum(roleName, out var role))
            throw new ArgumentException($"The role '{roleName}' is invalid. Please provide a valid user role.");

        await _userRepository.AddUserRoleAsync(userId, role);
    }

    public async Task DeleteUserRoleAsync(Guid userId, string roleName)
    {
        if (!RoleConverter.TryConvertToEnum(roleName, out var role))
            throw new ArgumentException($"The role '{roleName}' is invalid. Please provide a valid user role.");

        await _userRepository.DeleteUserRoleAsync(userId, role.ToString());
    }
    public async Task<List<User>> GetUsersWithSortAsync(int page, int pageSize, string? sortBy)
    {
        return await _userRepository.GetUsersWithSortAsync(page, pageSize, sortBy);
    }

}