using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Commands;

namespace MapMenuPlugin;
public partial class MapMenuPlugin : BasePlugin
{
    private void MapMenuCommand(CCSPlayerController? invoker, CommandInfo info)
    {
        if (invoker == null || !invoker.IsValid) return;

        // validate perms
        if (!invoker.HasPermission(Config!.CommandPerm))
        {
            invoker.PrintToChat(Localizer["Prefix"] + Localizer["NoPermission"]);
            return;
        }

        else
        {
            invoker.PrintToChat(Localizer["Prefix"] + Localizer["MapMenuOpen"]);
            // show the menu to the player
            invoker.ShowMenu(MapMenu!);
        }
    }
}