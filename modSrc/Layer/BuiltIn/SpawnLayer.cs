using LiveMap.Configuration;
using LiveMap.Layer.marker;
using LiveMap.Layer.marker.options;
using LiveMap.Util;

namespace LiveMap.Layer.BuiltIn;

public class SpawnLayer() : Layer("spawn", !string.IsNullOrEmpty(Config.IconOptions.Title) ? Config.IconOptions.Title : "lang.spawn".ToLang()) {
    public override int? Interval => Config.UpdateInterval;

    public override bool? Hidden => !Config.DefaultShowLayer;

    public override List<Marker> Markers {
        get {
            TooltipOptions? tooltip = Config.Tooltip?.DeepCopy();
            if (tooltip?.Content != null) {
                tooltip.Content = tooltip.Content;
            }

            PopupOptions? popup = Config.Popup?.DeepCopy();
            if (popup?.Content != null) {
                popup.Content = popup.Content;
            }

            return [
                new Icon("livemap:spawn", LiveMap.Api.Sapi.World.DefaultSpawnPosition.ToPoint(), Config.IconOptions) { Tooltip = tooltip, Popup = popup }
            ];
        }
    }

    public override string Filename => Path.Combine(Files.MarkerDir, $"{Id}.json");

    private static Spawn Config => LiveMap.Api.Config.Layers.Spawn;

    public override async System.Threading.Tasks.Task WriteToDisk(CancellationToken cancellationToken) {
        if (Config.Enabled) {
            await base.WriteToDisk(cancellationToken);
        }
    }
}
