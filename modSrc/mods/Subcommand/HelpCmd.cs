using System.Text;
using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Command.subcommand;

public class HelpCmd(LiveMap server) : AbstractCommand(server, ["help"]) {
    public override TextCommandResult Execute(TextCommandCallingArgs args) {
        StringBuilder sb = new();
        sb.AppendLine("command.help.available-commands".ToLang());

        foreach (AbstractCommand cmd in _server.CommandHandler.Commands) {
            sb.AppendLine($"  {cmd.Name[0]} - {cmd.Description}");
        }

        return TextCommandResult.Success(sb.ToString());
    }
}
