using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Projectiles.Weapons;

namespace TerrariaExpansionOfEverything.Content.Items.Weapons
{
    internal class Operator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Operator");
            Tooltip.SetDefault("One shot, one kill.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Item.staff[Item.type] = true;
        }
        public override void SetDefaults(){
            Item.height = 64;
            Item.width = 42;

            Item.scale = 2f;
            Item.sellPrice(gold: 50);
            Item.value = 2500;
            Item.maxStack = 1;

            
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 20;

            Item.noMelee = true;
            Item.damage = 40000;
            Item.knockBack = 50f;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item149;
            Item.useAmmo = AmmoID.Bullet;
            // Item.shoot = ProjectileID.FireArrow;

            // Tool Zone
            Item.shoot = ModContent.ProjectileType<SharpshooterRounds>();
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newPos = new Vector2(velocity.X * 1.6f, velocity.Y * 1.6f);
            position += newPos;
            // velocity = new Vector2(0, 100);
            //Sound 149
            if(type == ModContent.ProjectileType<SharpshooterRounds>())
            {
                velocity = velocity * 15f;
            }

            float recoil = -1f; // -1f
            player.velocity = velocity * recoil;
            int dustSize = 200;
            for (var i = 0; i < 120; i++)
            {
                Dust.NewDust(position + new Vector2(0f, -200f), dustSize, dustSize, 31, 0.25f, 0.25f ,1,  Color.Gray);
            }
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SharpshooterRounds>(), damage, knockback);
            return true;
        }
        
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 5)
                .Register();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 0);
        }
    }
}