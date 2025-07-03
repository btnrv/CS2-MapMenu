using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace MapMenuPlugin;
public class MapMenuConfig : BasePluginConfig
{
    [JsonPropertyName("maps_and_ids")]
    public Dictionary<string, long> MapsIds { get; set; } = new Dictionary<string, long>
    {
        { "jb_reborn_yaz", 3496798253 },
        { "jb_reborn_piramit", 3485017224 }
    };

    [JsonPropertyName("command_permission")]
    public string CommandPerm { get; set; } = "@css/root";

    [JsonPropertyName("command_aliases")]
    public List<string> CommandAliases { get; set; } = new List<string> { "css_mapmenu", "css_map" };

    [JsonPropertyName("menu_type")]
    public string MenuType { get; set; } = "WasdMenu";
}