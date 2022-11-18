using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using System;

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
        private ModNPC npc;
        private int counter = 0;

        public override void OnInitialize()
        {   
            
            
            area = new UIElement();
            
            area.Left.Set( Main.LocalPlayer.SpawnX - Main.screenPosition.X, 0f); // Place the resource bar to the left of the hearts.
            area.Top.Set(Main.LocalPlayer.SpawnY - Main.screenPosition.Y, 0f); // Placing it just a bit below the top of the screen.
            area.Width.Set(50, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
            area.Height.Set(50, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("TerrariaExpansionOfEverything/UI/npcIcon")); // Frame of our resource bar
            barFrame.Left.Set(22, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(20, 0f);
            barFrame.Height.Set(20, 0f);
            
            Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
            textUI = new UIText("0/0", 0.8f); // text to show stat
            textUI.Width.Set(40, 0f);
            textUI.Height.Set(0, 0f);
            textUI.Top.Set(0, 0f);
            textUI.Left.Set(10, 0f);
            
            area.Append(textUI);
            area.Append(barFrame);
            Append(area);
        }
        
        public override void Update(GameTime gameTime) {
            // Setting the text per tick to update and show our resource values.
            float distance = Utils.Distance(Main.LocalPlayer.position, Main.npc[22].position);
            textUI.SetText($"{distance}");
            area.Left.Set( Main.LocalPlayer.SpawnX - Main.screenPosition.X + counter, 0f); // Place the resource bar to the left of the hearts.
            area.Top.Set(500, 0f);
        }

    }
}