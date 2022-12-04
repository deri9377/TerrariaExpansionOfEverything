using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaExpansionOfEverything.Content.Pets.Projectile;

public class StarPlatinumProjectile: ModProjectile
{
    private const int DashCooldown = 1000; // How frequently this pet will dash at enemies.
		private const float DashSpeed = 20f; // The speed with which this pet will dash at enemies.
		private const int FadeInTicks = 30;
		private const int FullBrightTicks = 200;
		private const int FadeOutTicks = 30;
		private const float Range = 500f;

		private static readonly float RangeHypoteneus = (float)(Math.Sqrt(2.0) * Range); // This comes from the formula for calculating the diagonal of a square (a * √2)
		private static readonly float RangeHypoteneusSquared = RangeHypoteneus * RangeHypoteneus;

		// The following 2 lines of code are ref properties (learn about them in google) to the projectile.ai array entries, which will help us make our code way more readable.
		// We're using the ai array because it's automatically synchronized by the base game in multiplayer, which saves us from writing a lot of boilerplate code.
		// Note that the projectile.ai array is only 2 entries big. If you need more than 2 synchronized variables - you'll have to use fields and sync them manually.

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Annoying Light");
			Main.projFrames[Projectile.type] = 1;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
		}

		public override void SetDefaults() {
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.penetrate = -1;
			Projectile.netImportant = true;
			Projectile.timeLeft *= 5;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.scale = 0.8f;
			Projectile.tileCollide = false;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			if (!Main.dedServ) {
				Lighting.AddLight(Projectile.Center, Projectile.Opacity * 0.9f, Projectile.Opacity * 0.1f, Projectile.Opacity * 0.3f);
			}

			Movement(player);
		}
		
		
		private void Movement(Player player) {
			// Handles movement, returns true if moving fast (used for animation)
			float velDistanceChange = 2f;

			// Calculates the desired resting position, aswell as some vectors used in velocity/rotation calculations
			int dir = player.direction;
			Projectile.direction = Projectile.spriteDirection = dir;

			Vector2 desiredCenterRelative = new Vector2(-dir * 40, -30f);

			// Add some sine motion
			desiredCenterRelative.Y += (float)Math.Sin(Main.GameUpdateCount / 120f * MathHelper.TwoPi) * 5;

			Vector2 desiredCenter = player.MountedCenter + desiredCenterRelative;
			Vector2 betweenDirection = desiredCenter - Projectile.Center;
			float betweenSQ = betweenDirection.LengthSquared(); // It is recommended to operate on squares of distances, to save computing time on square-rooting

			if (betweenSQ > 1000f * 1000f || betweenSQ < velDistanceChange * velDistanceChange) {
				// Set position directly if too far away from the player, or when near the desired location
				Projectile.Center = desiredCenter;
				Projectile.velocity = Vector2.Zero;
			}

			if (betweenDirection != Vector2.Zero) {
				Projectile.velocity = betweenDirection * 0.1f * 2;
			}
			
			
			// If moving at regular speeds, rotate the projectile towards its default rotation (0) smoothly if necessary
			if (Projectile.rotation > MathHelper.Pi) {
				Projectile.rotation -= MathHelper.TwoPi;
			}

			if (Projectile.rotation > -0.005f && Projectile.rotation < 0.005f) {
				Projectile.rotation = 0f;
			}
			else {
				Projectile.rotation *= 0.96f;
			}
		}

}