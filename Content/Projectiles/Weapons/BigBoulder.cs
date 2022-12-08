using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

//Strategy Pattern Projectile for the "staff of mysteries" weapon
//See weapon for more detailed comments
namespace TerrariaExpansionOfEverything.Content.Projectiles.Weapons
 {
    internal class BigBoulder : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            
            Projectile.DamageType = DamageClass.Magic;

            Projectile.aiStyle = -1;

            Projectile.penetrate = -1;

            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            
        }
        //Custom AI class with gravitational abilities and non-active tile collision
        public override void AI()
        {
            Projectile.ai[0]++;
            Projectile.velocity.Y += 0.25f;
            if(Projectile.ai[0] < 60f){
                Projectile.velocity *= 1.01f;
            }
            else{
                Projectile.velocity *= 1.05f;
                if(Projectile.ai[0] >= 100){
                    Projectile.Kill();
                }
            }
            float rotationalSpeed = 0.4f * (float)Projectile.direction;
            Projectile.rotation += rotationalSpeed;

            Lighting.AddLight(Projectile.Center, 0.5f,0.5f,0.5f);
            if(Main.rand.NextBool(2))
            {
                int numToSpawn = Main.rand.Next(3);
                for(int i = 0; i < numToSpawn; i++){
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 59, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0);
                }
            }
        }
    }
}