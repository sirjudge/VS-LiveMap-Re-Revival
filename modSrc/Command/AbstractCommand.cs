using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Command;

public abstract class AbstractCommand {
    public readonly ICommandArgumentParser[] ArgParsers;
    public readonly bool RequiresPlayer;
    protected readonly LiveMap _server;

    protected AbstractCommand(LiveMap server, string[] name, string? privilege = null, bool requiresPlayer = false, params ICommandArgumentParser[] argParsers) {
        _server = server;

        Name = name;
        Description = $"command.{Name[0]}.description".ToLang();
        Privilege = privilege ?? Vintagestory.API.Server.Privilege.root;
        RequiresPlayer = requiresPlayer;
        ArgParsers = argParsers;
    }

    public string[] Name { get; }
    public string Description { get; }
    public string Privilege { get; }

    public abstract TextCommandResult Execute(TextCommandCallingArgs args);
}
