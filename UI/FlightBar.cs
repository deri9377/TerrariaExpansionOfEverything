using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using UIState = Terraria.UI.UIState;

namespace TerrariaExpansionOfEverything.UI
{
    public class FlightBar : UIState
    {
        public static bool visible;
        private string text;
        public UIPanel panel;
        private Vector2 position;
        private UIText textUI;
        private UIElement area;
        private UIImage barFrame;
        private Color gradientA;
        private Color gradientB;

        public FlightBar()
        {
            this.position = Main.LocalPlayer.position;
            this.text = string.Format("{0:f" + ModContent.GetInstance<Config>().Decimal + "}", Main.LocalPlayer.wingTime / 60f);
        }

        public FlightBar(Vector2 position, string text)
        {
            this.position = position;
            this.text = text;
        }
        
        public override void OnInitialize()
        {
            area = new UIElement();
            Vector2 position = Main.LocalPlayer.position - Main.screenPosition;
            area.Left.Set(-1000, 1f); // Place the resource bar to the left of the hearts.
            area.Top.Set(0, 0f); // Placing     it just a bit below the top of the screen.
            area.Width.Set(182, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
            area.Height.Set(30, 0f);

            barFrame = new UIImage(ModContent.Request<Texture2D>("TerrariaExpansionOfEverything/UI/ExampleResourceFrame")); // Frame of our resource bar
            barFrame.Left.Set(0, 0f);
            barFrame.Top.Set(0, 0f);
            barFrame.Width.Set(138, 0f);
            barFrame.Height.Set(34, 0f);
            
            textUI = new UIText("0/0", 0.8f); // text to show stat
            textUI.Width.Set(138, 0f);
            textUI.Height.Set(34, 0f);
            textUI.Top.Set(40, 0f);
            textUI.Left.Set(0, 0f);

            gradientA = new Color(123, 25, 138); // A dark purple
            gradientB = new Color(187, 91, 201); // A light purple

            area.Append(textUI);
            area.Append(barFrame);
            Append(area);
        }
        
        protected override void DrawSelf(SpriteBatch spriteBatch) {
            base.DrawSelf(spriteBatch);
            if (!Main.gameMenu && Main.LocalPlayer.wingTimeMax != Main.LocalPlayer.wingTime &&
                ModContent.GetInstance<Config>().FlightTimer && !Main.LocalPlayer.dead)
            {
                float quotient = (float)Main.LocalPlayer.wingTime / Main.LocalPlayer.wingTimeMax;
            
                // Here we get the screen dimensions of the barFrame element, then tweak the resulting rectangle to arrive at a rectangle within the barFrame texture that we will draw the gradient. These values were measured in a drawing program.
                Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
                hitbox.X += 12 ;
                hitbox.Width -= 24;
                hitbox.Y += 8;
                hitbox.Height -= 10;

                // Now, using this hitbox, we draw a gradient by drawing vertical lines while slowly interpolating between the 2 colors.
                int left = hitbox.Left;
                int right = hitbox.Right;
                int steps = (int)((right - left) * quotient);
                for (int i = 0; i < steps; i += 1) {
                    // float percent = (float)i / steps; // Alternate Gradient Approach
                    float percent = (float)i / (right - left);
                    spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
                }
            }
        }
        
        public override void Update(GameTime gameTime) {
            // Setting the text per tick to update and show our resource values.
            if (!Main.gameMenu && Main.LocalPlayer.wingTimeMax != Main.LocalPlayer.wingTime &&
                ModContent.GetInstance<Config>().FlightTimer && !Main.LocalPlayer.dead)
            {
                Append(area);
            }
            else
            {
                RemoveAllChildren();
            }

            Vector2 pos = Main.screenPosition - Main.LocalPlayer.position;
            area.Left.Set(- pos.X - 100, 0.1f);
            area.Top.Set(- pos.Y, 0.1f);
            textUI.SetText($"{Main.LocalPlayer.wingTime}, {Main.LocalPlayer.wingTimeMax}");
            base.Update(gameTime);
        }
    
    }
}