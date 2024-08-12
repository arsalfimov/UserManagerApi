namespace UM.Domain;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;
    public virtual List<Role>? Roles { get; set; }
}