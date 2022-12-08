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
        //Custom weapon item class
        //This class is for the rifle weapon and all functions below are utilized by only this object
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vandal");
            Tooltip.SetDefault("The classic");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Item stats assignments
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

            Item.noMelee = true;
            Item.damage = 60;
            Item.knockBack = 50f;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;
            // Tool Zone
            Item.shoot = AmmoID.Bullet;
            Item.shootSpeed = 10f;
        }
        //Custom shoot function to make the bullets appear from the barell of the weapon instead of center of player
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 newPos = new Vector2(velocity.X * 1.2f, velocity.Y * 1.2f);
            position += newPos;
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