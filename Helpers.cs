using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Modules.Admin;
using CS2MenuManager.API.Class;

namespace MapMenuPlugin;
public partial class MapMenuPlugin : BasePlugin
{
    void HostMap(long mapId)
    {
        // hosts the map, simple
        Server.ExecuteCommand($"host_workshop_map {mapId}");
    }

    // create menu object by config type
    public BaseMenu CreateMenuByType(string MenuType, string title)
    {
        return MenuManager.MenuByType(MenuType, title, this);
    }

    private BaseMenu BuildMenu()
    {
        // create menu by type from config
        BaseMenu? _mapMenu = CreateMenuByType(Config!.MenuType, Localizer["MapMenuTitle"]);

        // add each map to the menu
        foreach (var kvp in Config.MapsIds)
        {
            var displayName = kvp.Key;

            _mapMenu.AddItem(displayName, (player, option) =>
            {
                if (player == null || !player.IsValid) return;

                // close menu to prevent multiple inputs
                MenuManager.CloseActiveMenu(player);

                // get map id from config and host_workshop_map
                HostMap(kvp.Value);
            });
        }

        return _mapMenu;
    }
}

public static class Extensions
{
    public static bool HasPermission(this CCSPlayerController player, string permission)
    {
        if (player == null || !player.IsValid) return false;

        return AdminManager.PlayerHasPermissions(player, permission);
    }

    public static void ShowMenu(this CCSPlayerController player, CS2MenuManager.API.Class.BaseMenu menu)
    {
        if (player == null || !player.IsValid) return;

        if (menu == null) return;

        menu.Display(player, -1);
    }
}