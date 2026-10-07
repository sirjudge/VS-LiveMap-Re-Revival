using SkiaSharp;
using Vintagestory.API.Common;

namespace LiveMap.Data;

//TODO: Huge shout out to my boy @GrimGrum the one and only worlds greatest game and watch
// There's an issue somewhere in this renderer causing the map to be rendered as sepia for some reason
// I think it's because of the change of `.IndexOf()` which got nuked out of C# existence at some point
public class SepiaColors {
    public byte[] Block2Color { get; private set; }
    public bool[] BlockIsWater { get; private set; }
    public Vintagestory.API.Datastructures.OrderedDictionary<string, string> HexColorsByCode { get; } = new() {
        { "ink", "#483018" },
        { "settlement", "#856844" },
        { "wateredge", "#483018" },
        { "land", "#AC8858" },
        { "desert", "#C4A468" },
        { "forest", "#98844C" },
        { "road", "#805030" },
        { "plant", "#808650" },
        { "lake", "#CCC890" },
        { "ocean", "#CCC890" },
        { "glacier", "#E0E0C0" },
        { "unknown", "#FF1493" }
    };
    public Vintagestory.API.Datastructures.OrderedDictionary<string, uint> ColorsByCode { get; } = [];
    public SepiaColors(LiveMap server) {
        int max = server.Sapi.World.Blocks.Count;
        Block2Color = new byte[max + 1];
        BlockIsWater = new bool[max + 1];

        foreach (KeyValuePair<string, string> val in HexColorsByCode) {
            ColorsByCode[val.Key] = (uint)SKColor.Parse(val.Value);
        }

        foreach (Block block in server.Sapi.World.Blocks) {
            if (block.BlockMaterial == EnumBlockMaterial.Snow && block.Code.Path.Contains("snowblock")) {
                Block2Color[block.BlockId] = (byte)ColorsByCode.IndexOfKey("glacier");
                BlockIsWater[block.BlockId] = false;
                continue;
            }

            string colorCode = "land";
            if (block.Attributes != null) {
                colorCode = block.Attributes["mapColorCode"].AsString() ?? GetDefaultMapColorCode(block.BlockMaterial);
            }

            Block2Color[block.BlockId] = (byte)ColorsByCode.IndexOfKey(colorCode);
            BlockIsWater[block.BlockId] = block.BlockMaterial == EnumBlockMaterial.Water || (block.BlockMaterial == EnumBlockMaterial.Ice && block.Code.Path != "glacierice");
        }
    }

    public static string GetDefaultMapColorCode(EnumBlockMaterial material) {
        return material switch {
            EnumBlockMaterial.Soil => "land",
            EnumBlockMaterial.Sand => "desert",
            EnumBlockMaterial.Ore => "land",
            EnumBlockMaterial.Gravel => "desert",
            EnumBlockMaterial.Stone => "land",
            EnumBlockMaterial.Leaves => "forest",
            EnumBlockMaterial.Plant => "plant",
            EnumBlockMaterial.Wood => "forest",
            EnumBlockMaterial.Snow => "glacier",
            EnumBlockMaterial.Water => "lake",
            EnumBlockMaterial.Ice => "glacier",
            EnumBlockMaterial.Lava => "lava",
            _ => "unknown"
        };
    }
    public void Dispose() {
        ColorsByCode.Clear();
        HexColorsByCode.Clear();
        Block2Color = [];
        BlockIsWater = [];
    }
}
