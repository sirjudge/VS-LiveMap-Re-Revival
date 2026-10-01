using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Command.Argument;

public class CenterPositionArgParser(string argName, ICoreAPI api) : WorldPosition2DArgParser(argName, api, false) {
    public override string GetSyntaxExplanation(string indent) => $"{indent}{GetSyntax()} {"command.arg.center".ToLang()}";
}
