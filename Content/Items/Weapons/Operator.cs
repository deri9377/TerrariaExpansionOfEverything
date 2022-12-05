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
            Item.height = 32;
            Item.width = 32;


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
            Item.UseSound = SoundID.DD2_LightningAuraZap;
            Item.useAmmo = AmmoID.Bullet;
            // Item.shoot = ProjectileID.FireArrow;

            // Tool Zone
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Vector2 newPos = new Vector2(velocity.X * 1.2, velocity.Y * 1.2);
            // position += newPos;
            Projectile.NewProjectile(source, position * 3f, velocity, type, damage, knockback);
            return true;
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 5)
                .Register();
        }
    }
}