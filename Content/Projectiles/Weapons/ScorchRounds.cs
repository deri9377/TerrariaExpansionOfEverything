using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

//This is the backend class for the Scorch Round once it has been shot. It has a custom function to adds fire damage and the 
// "on fire!" debuff to enemies that are hit by this bullet.
namespace TerrariaExpansionOfEverything.Content.Projectiles.Weapons
 {
    internal class ScorchRounds : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 20;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            
            Projectile.DamageType = DamageClass.Ranged;

            Projectile.aiStyle = 1;

            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;
            Projectile.scale = 0.75f;
            Projectile.extraUpdates = 1;
            // Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);

        }
        public override void ModifyHitNPC( NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection )
        {
            target.AddBuff(24, 240 );
        }

        public override void AI()
        {
            Projectile.aiStyle = 0;
            Lighting.AddLight(Projectile.position, 0.3f, 0.3f, 0.75f);
            Lighting.Brightness(1,1);
        }

        public override void Kill(int timeLeft)
        {
            //PlaySound(0, (int)Projectile.position.X , (int)Projectile.position.Y, 21, 0.8f, 0.8f);
            for (var i = 0; i < 4; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 7, 0f, 0,1,  Color.Blue);
            }
        }
    }
}