using System.Text.Json;
using System.Text.Json.Serialization;
using LiveMap.Tile;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LiveMap.Json;

public class TileTypeJsonConverter : JsonConverter {
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
        if (value is TileType tileType) {
            writer.WriteValue(tileType.ToString());
        } else {
            writer.WriteNull();
        }
    }

    public override object? ReadJson(JsonReader reader, Type type, object? existingValue, JsonSerializer serializer) {
        if (reader.TokenType != JsonToken.String) {
            return null;
        }

        string? str = JToken.Load(reader).ToObject<string>();
        if (str is null) {
            return null;
        }

        return TileType.Types.GetValueOrDefault(str);
    }

    public override bool CanConvert(Type type) => type.GetElementType() == typeof(string);
}
