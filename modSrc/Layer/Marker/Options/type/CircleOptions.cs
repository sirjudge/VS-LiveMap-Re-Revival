using Newtonsoft.Json;

namespace LiveMap.Layer.Marker.Options.type;

/// <summary>
///     Optional settings for the <see cref="Circle" /> marker
/// </summary>
public class CircleOptions : PathOptions {
    /// <summary>
    ///     Radius of the circle, in blocks
    /// </summary>
    [JsonProperty(Order = 0)]
    public double? Radius { get; set; }
}
