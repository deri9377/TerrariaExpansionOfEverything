using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Pets.Projectile;

namespace TerrariaExpansionOfEverything.Content.Pets.Item;

//Stand child class for ZaWorld
public class ZaWorld : Stand
{

    public override void SetDefaults() {
        base.SetDefaults();
        Item.shoot = ModContent.ProjectileType<ZaWorldProjectile>();
    }


//Give player class a buff when equipped
    public override void UseStyle(Player player, Rectangle heldItemFrame) {
        if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
            player.AddBuff(Item.buffType, 3600);
        }
    }
    
    
    
    
}