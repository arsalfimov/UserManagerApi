namespace UM.Domain.Exceptions;

public sealed class RoleAlreadyExistsException
    : Exception
{
    public RoleAlreadyExistsException(string? roleName, string entity)
        : base($"The role '{roleName}' already assigned to the entity '{entity}'")
    {
    }
}