using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Pets.Projectile;

namespace TerrariaExpansionOfEverything.Content.Pets.Item;

public abstract class Stand : ModItem
{
    public override void SetDefaults() {
        Item.damage = 0;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.width = 16;
        Item.height = 30;
        Item.UseSound = SoundID.Item2;
        Item.useAnimation = 20;
        Item.useTime = 20;
        Item.rare = ItemRarityID.Yellow;
        Item.noMelee = true;
    }

    // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    public override void UseStyle(Player player, Rectangle heldItemFrame) {
        if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
            player.AddBuff(Item.buffType, 3600);
        }
    }
}