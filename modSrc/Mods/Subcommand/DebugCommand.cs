using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Mods.Subcommand;

//TODO: Need to add document code to this in README
public class DebugEnableCommand(LiveMap server) : AbstractCommand(server, ["debug", "d"])
{
    public override TextCommandResult Execute(TextCommandCallingArgs args)
    {
        const string debugStatusText = "Debug Mode enabled";
        _server.Config.DebugMode = true;
        return debugStatusText.CommandSuccess();
    }
}

public class DebugDisableCommand(LiveMap server) : AbstractCommand(server, ["debugDisable", "dd"])
{
    public override TextCommandResult Execute(TextCommandCallingArgs args)
    {
        const string debugStatusText = "Debug Mode disabled";
        _server.Config.DebugMode = false;
        return debugStatusText.CommandSuccess();
    }
}

public class DebugStatusCommand(LiveMap server) : AbstractCommand(server, ["debugStatus", "ds"])
{
    public override TextCommandResult Execute(TextCommandCallingArgs args)
    {
        string debugStatus = $"Debug Mode status:{_server.Config.DebugMode}";
        return debugStatus.CommandSuccess();
    }
}
