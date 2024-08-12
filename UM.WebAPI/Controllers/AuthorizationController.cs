using MC.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UM.PersistenceImplementations;
using UM.WebAPI.DTO;

namespace MC.WebApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly TokenProvider _tokenService;

    public AuthController(UserManager<IdentityUser> userManager, ApplicationDbContext context, TokenProvider tokenService)
    {
        _userManager = userManager;
        _context = context;
        _tokenService = tokenService;
    }


    [HttpPost]
    [SwaggerOperation(
    Summary = "Registration.",
    Description = "Registration."
    )]
    public async Task<ActionResult> Register(RegisterDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new IdentityUser { UserName = request.Username, Email = request.Email },
            request.Password
        );
        if (result.Succeeded)
        {
            request.Password = "";
            return CreatedAtAction(nameof(Register), new { email = request.Email }, request);
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return BadRequest(ModelState);
    }

    [HttpPost]
    [SwaggerOperation(
    Summary = "Authentication.",
    Description = "Authentication for obtaining a token."
    )]
    public async Task<ActionResult<TokenResponse>> Login([FromBody] LoginDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var managedUser = await _userManager.FindByNameAsync(request.Username);

        if (managedUser is null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var accessToken = _tokenService.CreateToken(managedUser);
        await _context.SaveChangesAsync();

        return Ok(new TokenResponse
        {
            Username = managedUser.UserName,
            Email = managedUser.Email,
            Token = accessToken,
        });

    }

    [Authorize]
    [HttpGet("/GetMyId")]
    [SwaggerOperation(
    Summary = "Data about the authorized user.",
    Description = "Data about the authorized user."
    )]
    public async Task<ActionResult> GetUserId()
    {
        var id = User.FindFirst("UserId").Value;
        return Ok(id);
    }
}

