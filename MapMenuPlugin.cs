using CounterStrikeSharp.API.Core;
using CS2MenuManager.API.Class;
using Microsoft.Extensions.Logging;

namespace MapMenuPlugin;
public partial class MapMenuPlugin : BasePlugin, IPluginConfig<MapMenuConfig>
{
    public override string ModuleName => "MapMenuPlugin";
    public override string ModuleAuthor => "gyro & belali yusuf";
    public override string ModuleVersion => "1.0.0";
    public MapMenuConfig Config { get; set; } = default!;
    public BaseMenu? MapMenu { get; set; }
    public override void Load(bool hotReload)
    {
        foreach (var alias in Config.CommandAliases)
        {
            AddCommand(alias, Localizer["MapMenuDescription"], MapMenuCommand);
        }
    }

    public void OnConfigParsed(MapMenuConfig config)
    {
        if (config.MapsIds == null || config.MapsIds.Count == 0)
        {
            Logger.LogError("No maps defined in MapMenu configuration.");
            return;
        }

        foreach (var map in config.MapsIds)
        {
            Logger.LogInformation($"Map Name: {map.Key}, Map ID: {map.Value}");
        }

        Config = config;
        MapMenu = BuildMenu();
    }
}
