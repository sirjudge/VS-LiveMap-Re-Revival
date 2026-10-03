using LiveMap.Json;
using LiveMap.Tile;
using Newtonsoft.Json;

namespace LiveMap.Configuration;

public class Web {
    public string Path { get; set; } = "web/";

    public string Url { get; set; } = "http://localhost:8080";

    public bool ReadOnly { get; set; }

    [JsonConverter(typeof(TileTypeJsonConverter))]
    public TileType TileType { get; set; } = TileType.Webp;

    public int TileQuality { get; set; } = 100;

    public bool FriendlyUrls { get; set; }
}
