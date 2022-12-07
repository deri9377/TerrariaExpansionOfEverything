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
    internal class Vandal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vandal");
            Tooltip.SetDefault("The classic");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Item.staff[Item.type] = true;
        }
        public override void SetDefaults(){
            Item.height = 32;
            Item.width = 32;


            Item.sellPrice(gold: 50);
            Item.value = 2500;
            Item.maxStack = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 5;
            Item.useStyle = 5;
            Item.useAnimation = 5;
//            Item.range = true;

            Item.noMelee = true;
            Item.damage = 60;
            Item.knockBack = 50f;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;
            // Item.shoot = ModContent.ProjectileType<SharpshooterRounds>();
            // Item.shoot = ProjectileID.FireArrow;

            // Tool Zon
            Item.shoot = AmmoID.Bullet;
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newPos = new Vector2(velocity.X * 1.2f, velocity.Y * 1.2f);
            position += newPos;
            // velocity = new Vector2(0, 100);
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