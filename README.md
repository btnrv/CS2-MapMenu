# CS2-MapMenu

A simple Counter-Strike 2 server plugin that provides an in-game menu for loading workshop maps by name, so you don’t have to remember or re-type map IDs each time you run `host_workshop_map`.

<p align="center"> <img src="https://i.hizliresim.com/ray3fxd.png" alt="MapMenu Screenshot" width="300"/> </p>

## Installation

1. **Download** the plugin and place it into the server files.
2. **Restart** your server.

## ⚠️ Required Configuration

Edit `configs/plugins/MapMenuPlugin/Mapmenuplugin.cfg` to list your frequently used maps. Example config will be created after installing the plugin correctly.

```cfg
{
  "maps_and_ids": {
    "jb_reborn_yaz": 3496798253,
    "jb_reborn_piramit": 3485017224
  },

  "command_permission": "@css/root",
  "command_aliases": [
    "css_mapmenu",
    "css_map"
  ],

  "menu_type": "WasdMenu",
  "ConfigVersion": 1
}```