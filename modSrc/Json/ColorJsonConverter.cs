using LiveMap.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LiveMap.Json;

/// <summary>
///     Converter for Color to/from string/uint
/// </summary>
public class ColorJsonConverter : JsonConverter {
    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
        if (value is Color color) {
            writer.WriteValue(color.ToString());
        } else {
            writer.WriteNull();
        }
    }

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type type, object? existingValue, JsonSerializer serializer) {
        return reader.TokenType switch {
            JsonToken.String => (Color)JToken.Load(reader).ToObject<string>()!,
            not JsonToken.Integer => (object?)null,
            _ => (Color)JToken.Load(reader).ToObject<uint>()
        };
    }

    /// <inheritdoc />
    public override bool CanConvert(Type type) => type.GetElementType() == typeof(string) || type.GetElementType() == typeof(uint) || type.GetElementType() == typeof(int);
}
