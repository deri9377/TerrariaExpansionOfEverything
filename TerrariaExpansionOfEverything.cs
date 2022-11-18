using Terraria.ModLoader;
using Terraria;
using Terraria.UI;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.UI;


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
    

    public class NPCFinderMod : ModSystem
    {
        private UserInterface NPCfinderInterface;
        internal NPCFinder npcFinder;
        public override void Load()
        {
            if (!Main.dedServ) {
                npcFinder = new();
                NPCfinderInterface = new();
                NPCfinderInterface.SetState(npcFinder);
            }
        }
        
        public override void UpdateUI(GameTime gameTime)
        {
            NPCfinderInterface?.Update(gameTime);
        }
        
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1) {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "NPCFinder: Find NPC",
                    delegate {
                        npcFinder.Draw(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
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
                    delegate
                    {
                        FlightBar.Draw(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
    
    

}