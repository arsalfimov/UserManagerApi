using System.ComponentModel.DataAnnotations;

namespace UM.WebAPI.DTO;

public class LoginDto
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
