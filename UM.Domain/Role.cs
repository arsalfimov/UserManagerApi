using System.Text.Json.Serialization;

namespace UM.Domain;

public class Role
{
    public int Id { get; set; }
    public UserRole Name { get; set; }
    [JsonIgnore]
    public virtual List<User>? Users { get; set; }
}

