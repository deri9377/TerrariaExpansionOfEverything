using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using log4net.Appender;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using TerrariaExpansionOfEverything.UI;
using UIScrollbar = On.Terraria.GameContent.UI.Elements.UIScrollbar;
using Utils = On.Terraria.Utils;


namespace TerrariaExpansionOfEverything
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

        private UserInterface FlightTimerInterface;
        internal FlightBar FlightBar;
        
        public override void Load() {
            // All code below runs only if we're not loading on a server
            if (!Main.dedServ) {
                FlightBar = new();
                FlightTimerInterface = new();
                FlightTimerInterface.SetState(FlightBar);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            FlightTimerInterface?.Update(gameTime);
        }
        
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1) {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "FlightTimer: Fligh Time",
                    delegate {
                        FlightBar.Draw(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }

}