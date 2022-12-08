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
    internal class Spectre : ModItem
    {
        //Custom weapon item class
        //This class is for the SMG weapon and all functions below are utilized by only this object
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre");
            Tooltip.SetDefault("Just a whisper");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Weapon stat assignment
        public override void SetDefaults(){
            Item.height = 32;
            Item.width = 32;


            Item.sellPrice(gold: 50);
            Item.value = 2500;
            Item.maxStack = 1;

            Item.DamageType = DamageClass.Ranged;
            Item.useTime = 2;
            Item.useStyle = 5;
            Item.useAnimation = 5;

            Item.noMelee = true;
            Item.damage = 60;
            Item.knockBack = 50f;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item11;
            Item.useAmmo = AmmoID.Bullet;

            Item.shoot = AmmoID.Bullet;
            Item.shootSpeed = 10f;
        }
        //Custom shoot function that adds randomness to simulate human inaccuracy 
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Random r = new Random();
            int range = 1;
            double randVal = r.NextDouble()* range;
            float rand_val = (float)randVal;
            //Randomize the bullet angle for inaccuracy
            Vector2 new_velocity = new Vector2(velocity.X + rand_val, velocity.Y + rand_val);
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