using UM.Domain;

namespace UM.Services.Converters;

public static class RoleConverter
{
    public static bool TryConvertToEnum(string value, out UserRole role)
    {
        role = UserRole.User;

        switch (value.ToLower())
        {
            case "user":
                role = UserRole.User;
                break;
            case "admin":
                role = UserRole.Admin;
                break;
            case "support":
                role = UserRole.Support;
                break;
            case "superadmin":
                role = UserRole.SuperAdmin;
                break;
            default:
                return false;
        }

        return true;
    }
}