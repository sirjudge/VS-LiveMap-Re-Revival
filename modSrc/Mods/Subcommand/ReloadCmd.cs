using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Mods.Subcommand;

public class ReloadCmd(LiveMap server) : AbstractCommand(server, ["reload"]) {
    public override TextCommandResult Execute(TextCommandCallingArgs args) {
        _server.Reload();

        return "reload.done".CommandSuccess();
    }
}
