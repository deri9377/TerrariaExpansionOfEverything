using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Pets.Projectile;

namespace TerrariaExpansionOfEverything.Content.Pets.Item;

public class ZaWorld : Stand
{

    public override void SetDefaults() {
        base.SetDefaults();
        Item.shoot = ModContent.ProjectileType<ZaWorldProjectile>();
    }

    // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

    public override void UseStyle(Player player, Rectangle heldItemFrame) {
        if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
            player.AddBuff(Item.buffType, 3600);
        }
    }
    
    
    
    
}