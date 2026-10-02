using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Mods.Subcommand;

public class StatusCommand(LiveMap server) : AbstractCommand(server, ["status", "progress"]) {
    public override TextCommandResult Execute(TextCommandCallingArgs args) {
        (int buffer, int process) = _server.RenderTaskManager?.GetCounts() ?? (0, 0);
        return process == 0 ? "status.idle".CommandSuccess(buffer) : "status.running".CommandSuccess(process);
    }
}
