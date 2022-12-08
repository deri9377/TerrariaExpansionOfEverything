using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Mounts;
using TerrariaExpansionOfEverything.Content.Pets.Projectile;

namespace TerrariaExpansionOfEverything.Content.Pets.Item;

//Stand Child class for Star Platinum
public class StarPlatinum : Stand
{

    public override void SetDefaults()
    {
        base.SetDefaults();
        Item.shoot = ModContent.ProjectileType<StarPlatinumProjectile>();
    }
    
}