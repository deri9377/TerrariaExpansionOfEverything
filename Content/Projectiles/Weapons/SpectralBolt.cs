using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

//Strategy Pattern Projectile for the "staff of mysteries" weapon
//See weapon for more detailed comments
namespace TerrariaExpansionOfEverything.Content.Projectiles.Weapons
 {
    internal class SpectralBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;

            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            
            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = 1;

            Projectile.penetrate = 1;
            Projectile.timeLeft = 400;

            Projectile.extraUpdates = 1;

            
        }
        int bounce = 0;
        int maxBounces = 6;
        //Custom AI function to allow the projectiles to bounce along the surface as they collide with tiles, and also
        // to create a flaming dust trail
        public override void AI()
        {
            Projectile.ai[0]++;
            if(Projectile.ai[0] >= 400){
                    Projectile.Kill();
                }

            Lighting.AddLight(Projectile.Center, 0.2f,0.2f,0.6f);
            Lighting.Brightness(1,1);
            if(Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for(int i = 0; i < 10; i++){
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 59, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0);
                }
            }
        }
        public override void Kill(int timeleft){
            if(Projectile.ai[0] < 400){
                Projectile.velocity = -Projectile.velocity;
                Projectile.rotation = -Projectile.rotation;
                return;
            }
            else{
                // Main.PlaySound(0, (int)Projectile.position.X, (int)Projectile.position.Y, 21, 0.9f, 0.9f);
                for(int i = 0; i < 100; i++){
                        Dust.NewDust(Projectile.position, Projectile.width * 3, Projectile.height * 3, 235, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0);
                }
                base.Kill(timeleft);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity){
            bounce++;
            for(int i = 0; i < 15; i++){
                        Dust.NewDust(Projectile.position, Projectile.width * 3, Projectile.height * 3, 235, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0);
                }
            if (Projectile.velocity.X != oldVelocity.X){
                Projectile.velocity.X = oldVelocity.X * -1;
            }
            if (Projectile.velocity.Y != oldVelocity.Y){
                Projectile.velocity.Y = oldVelocity.Y * -1;
            }
            Projectile.aiStyle = 1;
            if(bounce >= maxBounces){
                return true;
            }
            else{
                return false;
            }
        }
    }
}