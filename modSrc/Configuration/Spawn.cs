using LiveMap.Layer.marker.options;
using LiveMap.Layer.marker.options.type;
using Point = LiveMap.Data.Point;

namespace LiveMap.Configuration;

public class Spawn {
    public bool Enabled { get; set; } = true;

    public int UpdateInterval { get; set; } = 30;

    public bool DefaultShowLayer { get; set; } = true;

    public IconOptions IconOptions { get; set; } = new() { Title = "", Alt = "Spawn", IconUrl = "#svg-house", IconSize = new Point(16, 16) };

    public TooltipOptions? Tooltip { get; set; } = new() { Direction = "top", Content = "Spawn" };

    public PopupOptions? Popup { get; set; }

    public string? Css { get; set; }
}
