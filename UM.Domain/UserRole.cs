using System.Runtime.Serialization;

namespace UM.Domain;

public enum UserRole
{
    [EnumMember(Value = "User")]
    User,

    [EnumMember(Value = "Admin")]
    Admin,

    [EnumMember(Value = "Support")]
    Support,

    [EnumMember(Value = "SuperAdmin")]
    SuperAdmin
}