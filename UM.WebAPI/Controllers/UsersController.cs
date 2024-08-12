using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UM.Domain;
using UM.Services.DTOs;
using UM.Services.Interfaces;

namespace UM.WebAPI.Controllers;

[Authorize]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [SwaggerOperation(
            Summary = "Retrieves the collection of users.",
            Description = "Retrieves the collection of users."
        )]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
            Summary = "Retrieves a user.",
            Description = "Retrieves a user by ID."
        )]
    public async Task<ActionResult<User>> GetUserById(
        [SwaggerParameter("User Id", Required = true)] Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    [SwaggerOperation(
            Summary = "Creates a user.",
            Description = "Creates a user."
        )]
    public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userService.CreateUserAsync(userDto);
        return Created($"/users/{user.Id}", user);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
            Summary = "Updates a user.",
            Description = "Updates a user."
        )]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedUser = await _userService.UpdateUserAsync(id, userDto);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}/remove")]
    [SwaggerOperation(
        Summary = "Remove a user.",
        Description = "Remove a user."
    )]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }

    [HttpPost("{id}/addrole")]
    [SwaggerOperation(
        Summary = "Adds a role to the user.",
        Description = "Adds a role to the user. Available roles: (user, support, admin, superadmin)."
    )]
    public async Task<IActionResult> AddUserRole(Guid id,
        [SwaggerParameter(Required = true)] string role)
    {
        await _userService.AddUserRoleAsync(id, role);
        return Ok();
    }

    [HttpDelete("{id}/deleterole/{roleName}")]
    [SwaggerOperation(
        Summary = "Deletes a user role.",
        Description = "Deletes a user role. Available roles: (user, support, admin, superadmin)."
    )]
    public async Task<IActionResult> DeleteUserRole(Guid id,
        [SwaggerParameter(Required = true)] string roleName)
    {
        await _userService.DeleteUserRoleAsync(id, roleName);
        return Ok();
    }

    [HttpGet("{id}/roles")]
    [SwaggerOperation(
    Summary = "Gets user roles.",
    Description = "Gets user roles."
    )]
    public async Task<ActionResult<List<string>>> GetUserRoles(Guid id)
    {
        var roles = await _userService.GetUserRolesAsync(id);
        return Ok(roles);
    }

    [HttpGet("sort")]
    [SwaggerOperation(
    Summary = "Retrieves a collection of sorted users.",
    Description = "Retrieves a collection of users sorted by the specified parameters name: (a->z), " +
        "age (ascending), email (a->z), role (by quantity)."
    )]
    public async Task<ActionResult<List<User>>> SortUsers(
        [SwaggerParameter("Number of pages.", Required = true)] int page,
        [SwaggerParameter("The amount of content per page.", Required = true)] int pageSize,
        [SwaggerParameter("Sorting by content (params: name, age, email, role).")] string sortBy)
    {
        var users = await _userService.GetUsersWithSortAsync(page, pageSize, sortBy);
        return Ok(users);
    }
}
