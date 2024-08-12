using System.Text.Json;
using System.Text.Json.Serialization;

namespace UM.Domain;

public class UserRoleConverter : JsonConverter<UserRole>
{
    public override UserRole Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            if (Enum.TryParse(reader.GetString(), out UserRole role))
            {
                return role;
            }
        }
        throw new JsonException($"Invalid UserRole value: {reader.GetString()}");
    }

    public override void Write(Utf8JsonWriter writer, UserRole value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
