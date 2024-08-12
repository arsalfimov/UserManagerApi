using System.ComponentModel.DataAnnotations;

namespace UM.Services.DTOs;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Age is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Age must be a positive number.")]
    public int Age { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Incorrect format of the email address.")]
    public string Email { get; set; } = null!;
}
