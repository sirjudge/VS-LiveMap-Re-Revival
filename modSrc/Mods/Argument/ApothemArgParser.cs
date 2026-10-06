using LiveMap.Util;
using Vintagestory.API.Common;

namespace LiveMap.Mods.Argument;

public class ApothemArgParser(string argName) : IntArgParser(argName, 0, true) {
    public override string GetSyntaxExplanation(string indent) =>
        $"{indent}{GetSyntax()} {"command.arg.apothem".ToLang()}";
}
