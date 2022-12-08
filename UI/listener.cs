using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using System;
using Terraria.Chat;
using Terraria.Localization;

//This listener class is part of the observer pattern and functions as the publisher for sending NPC positional data
//to the other NPC finder related classes
namespace TerrariaExpansionOfEverything.UI
{
    public class listener : UIElement
    {
        public static bool visible = false;
        private int npcIndex = 22;
        private NPC npc = new NPC();
        private int counter = 0;
        public void setNPC(NPC npc)
        {
            this.npc = npc;
        }

        public NPC getNPC()
        {
            return npc;
        }

        public NPC[] GetAllNPCLocations()
        {
            return Main.npc;
        }
    }
}
