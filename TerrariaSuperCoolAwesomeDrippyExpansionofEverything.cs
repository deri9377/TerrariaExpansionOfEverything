using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using UIScrollbar = On.Terraria.GameContent.UI.Elements.UIScrollbar;
using Utils = On.Terraria.Utils;


namespace TerrariaSuperCoolAwesomeDrippyExpansionofEverything
{
	public class SimpleModPlayer : ModPlayer
	{


	    public override void OnEnterWorld(Player player) {
            player.extraAccessorySlots = 10;
            player.extraAccessory = true;
            player.lifeRegen = 100;
            player.statLife = 9000;
            player.statLifeMax = 9000;
            player.statLifeMax2 = 9000;
            player.pickSpeed = 0.0001f;
	    }
	}

	public class Teleporter : ModItem {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Teleporter");
            Tooltip.SetDefault("Click somewhere to teleport!");

        }

        public override bool? UseItem(Player player) {
            player.Teleport(Main.MouseWorld);
            return true;
        }

        public override void SetDefaults() {
            Item.width = 32;
            Item.height = 32;

            Item.useStyle = TeleportationStyleID.Portal;
        }
    }
    
    public class FlightTimer : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseText = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

            if (mouseText != -1)
            {
                layers.Insert(mouseText, new LegacyGameInterfaceLayer("FlightTimer: Flight Timer", delegate
                {
                    if (!Main.gameMenu && Main.LocalPlayer.wingTimeMax != Main.LocalPlayer.wingTime && ModContent.GetInstance<Config>().FlightTimer && !Main.LocalPlayer.dead)
                    {
                        string text = string.Format("{0:f" + ModContent.GetInstance<Config>().Decimal + "}", Main.LocalPlayer.wingTime / 60f);
                        Vector2 position = ModContent.GetInstance<Config>().Position * new Vector2(Main.screenWidth, Main.screenHeight);

                        Utils.DrawBorderString(Main.spriteBatch, text, position, Color.WhiteSmoke);
                    }

                    return true;
                }, InterfaceScaleType.UI));
            }
        }
    }

}