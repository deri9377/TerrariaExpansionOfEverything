using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerrariaExpansionOfEverything.UI;

public class AmmoCounter : ModSystem
{
    //OBSERVER PATTERN PIECE
//This is the UI class used by the main mod controller to display the players current ammo count to the user interface
    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
        int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
        if (resourceBarIndex != -1) {
            layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                "Ammo Counter: Ammo Counter",
                delegate
                {
                    int ammoSlot = -1;
                    for (int i = 0; i < Main.LocalPlayer.inventory.Length; i++)
                    {
                        if (Main.LocalPlayer.HeldItem.useAmmo == Main.LocalPlayer.inventory[i].ammo)
                        {
                            ammoSlot = i;
                        }
                    }
                    Utils.DrawBorderString(Main.spriteBatch, $"{Main.LocalPlayer.inventory[ammoSlot].stack}", new Vector2(Main.mouseX + 10, Main.mouseY - 10), Color.Red, scale:1f);
                    //Utils.DrawBorderString(Main.spriteBatch, $"{Main.LocalPlayer.heldProj}", new Vector2(Main.mouseX - 10, Main.mouseY - 10), Color.Red, scale:0.7f);
                    return true;
                },
                InterfaceScaleType.UI)
            );  
        }
    }
}

