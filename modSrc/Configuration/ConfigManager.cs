using LiveMap.Util;
using Newtonsoft.Json;
using Vintagestory.API.Config;

namespace LiveMap.Configuration;

public sealed class ConfigManager : IDisposable {
    private readonly FileWatcher _fileWatcher;
    private readonly LiveMap _server;

    public ConfigManager(LiveMap server) {
        _server = server;
        _fileWatcher = new FileWatcher(server);
        Load();
    }

    public Config Config { get; private set; } = null!;

    public void Load() {
        string modJsonPath = $"{_server.ModId}.json";
        Config? loadedConfig = _server.Sapi.LoadModConfig<Config>(modJsonPath);
        if (loadedConfig is null) {
            Logger.Warn("config json was unable to be loaded so default configuration will be used instead");
            loadedConfig = new Config();
        }
        Config = loadedConfig;
    }

    public void Save() {
        _fileWatcher.IgnoreChanges = true;

        FileInfo fileInfo = new(Path.Combine(GamePaths.ModConfig, $"{_server.ModId}.json"));
        GamePaths.EnsurePathExists(fileInfo.Directory!.FullName);
        string json = JsonConvert.SerializeObject(Config, Files.JsonSerializerPrettySettings);
        File.WriteAllText(fileInfo.FullName, json);

        _server.Sapi.Event.RegisterCallback(_ => _fileWatcher.IgnoreChanges = false, 100);
    }

    public void Reload() {
        Load();
        Save();
    }

    public void Dispose() =>
        _fileWatcher.Dispose();
}
