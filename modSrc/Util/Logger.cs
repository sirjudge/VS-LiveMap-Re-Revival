using Vintagestory.API.Common;

namespace LiveMap.Util;

public abstract class Logger {
    private static string Format(string message) => $"[LiveMap] {message}";

    private static ILogger Log() => LiveMap.Api.Sapi.Logger;

    public static void Debug(string message) {
        if (LiveMap.Api.Config.DebugMode) {
            Log().Event(Format($"[Debug] {message}"));
        }
    }

    public static void Info(string message) => Log().Event(Format(message));

    public static void Warn(string message) => Log().Warning(Format(message));

    public static void Error(string message) => Log().Error(Format(message));
}
