using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TerrariaExpansionOfEverything.Content.Projectiles.Weapons
 {
    internal class SharpshooterRounds : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 20;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            
            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 1;

            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;
            Projectile.scale = 0.75f;
            Projectile.extraUpdates = 1;
            // Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            
        }
        public override void AI()
        {
            Projectile.aiStyle = 0;
            Lighting.AddLight(Projectile.position, 0.3f, 0.3f, 0.75f);
            Lighting.Brightness(1,1);
        }
    }
}