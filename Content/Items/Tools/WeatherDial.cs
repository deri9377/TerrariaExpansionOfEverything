using System;
using Microsoft.Xna.Framework;
using On.Terraria.GameContent.UI.Elements;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerrariaExpansionOfEverything.Content.Items.Tools;

public class WeatherDial : ModItem
{
    private String[] events = new[] { "Rain", "Sandstorm", "Thunderstorm", "Wind", "Windy Day" };

    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Weather Dial");
        Tooltip.SetDefault("Click to change the Weather!");

    }

    public override bool? UseItem(Player player)
    {
        String s = "";
        if (Main.raining)
        {
            Main.raining = false;
            s += "Stopped Raining";
        }
        else
        {
            Main.raining = true;
            s += "Started Raining";
        }
        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(s), Color.Orange);
        return true;
    }
    
    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = TeleportationStyleID.MagicConch;
    }
}