using LiveMap.Layer.Marker.Options;
using LiveMap.Layer.Marker.Options.type;
using Point = LiveMap.Data.Point;

namespace LiveMap.Configuration;

public class Translocators {
    public bool Enabled { get; set; } = false;

    public int UpdateInterval { get; set; } = 30;

    public bool DefaultShowLayer { get; set; } = false;

    public IconOptions IconOptions { get; set; } = new() {
        Title = "",
        Alt = "",
        IconUrl = "#svg-spiral",
        IconSize = new Point(16, 16),
        Pane = "translocators"
    };

    public TooltipOptions? Tooltip { get; set; } = new() { Direction = "top", Content = "{0}<br>{1}" };

    public PopupOptions? Popup { get; set; }

    public string? Css { get; set; } = ".livemap-marker-translocator { color: #2d704e; }";
}
