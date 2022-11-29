using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using System;
using Terraria.Chat;
using Terraria.Localization;

namespace TerrariaExpansionOfEverything.UI
{

//Guide ID = 22

    public class NPCFinder : UIState
    {
        public static bool visible;
        private Vector2 position;
        private UIElement area;
        private UIImage barFrame;
        private UIText textUI;
        private int npcIndex = 22;
        private NPC npc = new NPC();
        private int counter = 0;

        public NPCFinder(NPC npc)
        {
            this.npc = npc;
        }

        public void setNPC(NPC npc)
        {
            this.npc = npc;
        }

        public NPC getNPC()
        {
            return npc;
        }
        

        public override void OnInitialize()
        {   
            
            
            area = new UIElement();
            Vector2 pos = npc.position - Main.screenPosition;
            
            area.Left.Set( pos.X, 0f); // Place the resource bar to the left of the hearts.
            area.Top.Set(pos.Y, 0f); // Placing it just a bit below the top of the screen.
            area.Width.Set(0, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
            area.Height.Set(0, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("TerrariaExpansionOfEverything/UI/npcIcon")); // Frame of our resource bar
            barFrame.Left.Set(0, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(0, 0f);
            barFrame.Height.Set(0, 0f);
            
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            textUI = new UIText("0/0", 0.8f); // text to show stat
            textUI.Width.Set(0, 0f);
            textUI.Height.Set(0, 0f);
            textUI.Top.Set(0, 0f);
            textUI.Left.Set(0, 0f);
            
            area.Append(textUI);
            area.Append(barFrame);
            Append(area);
        }
        
        public override void Update(GameTime gameTime) {
            // Setting the text per tick to update and show our resource values.
            string key = $"Position of npc is {npc.position}";
            //ChatHelper.BroadcastChatMessage(NetworkText.FromKey(key), Color.Orange);
            float distance = Utils.Distance(Main.LocalPlayer.position, npc.position);
            textUI.SetText($"{distance}");
            area.Left.Set( npc.position.X - Main.screenPosition.X, 0f); // Place the resource bar to the left of the hearts.
            area.Top.Set(npc.position.Y - Main.screenPosition.Y, 0f);
            ChatHelper.BroadcastChatMessage(NetworkText.FromKey($"{Main.MouseWorld - Main.screenPosition},image {area.Left.GetValue(0)}, {area.Top.GetValue(0)}"), Color.Orange);
            if (distance < 50)
            {
                RemoveAllChildren();
            }
        }
        

    }
}