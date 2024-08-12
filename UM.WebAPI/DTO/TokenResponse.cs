namespace UM.WebAPI.DTO;

public class TokenResponse
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Token { get; set; } = null!;
}