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
    internal class StaffOfMysteries : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Mysteries");
            Tooltip.SetDefault("Feeling lucky, kid?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
        }
        public override void SetDefaults(){
            Item.height = 32;
            Item.width = 32;


            Item.sellPrice(gold: 5);
            Item.maxStack = 1;

            
            Item.useTime = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 5;

            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 40;
            Item.knockBack = 50f;
            Item.mana = 1;
            Item.autoReuse = true;

            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.DD2_LightningAuraZap;
            // Item.shoot = ProjectileID.FireArrow;

            // Tool Zone
            Item.shootSpeed = 10f;
        }
        public override void OnConsumeMana(Player player, int manaConsumed)
        {
            var randValue = new Random();
            var projectilesList = new List<int>{ModContent.ProjectileType<BigBoulder>(), ModContent.ProjectileType<SpectralBolt>()};
            int index = randValue.Next(projectilesList.Count);
            int newType = projectilesList[index];
            Item.shoot = newType;
            base.OnConsumeMana(player, manaConsumed);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Vector2 newPos = new Vector2(100f, position.Y + 100f);
            // Projectile.NewProjectile(source, newPos * 20f, velocity, type, damage, knockback);
            return true;
            // return base.Shoot(player, source, newPos, velocity, type, damage, knockback);
        }
        // public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        // {
        //     int randValue = (Main.rand.Next(5));
        //     int newType = 0;
        //     if(randValue == 0){       
        //         newType = 5;
        //     }
        //     if(randValue == 1){
        //         newType = 19;
        //     }
        //     if(randValue == 2){
        //         newType = 47;
        //     }
        //     if(randValue == 3){
        //         newType = 75;
        //     }
        //     else{
        //         newType = 2;
        //     }
        //     Projectile.NewProjectile(source , position, velocity, 1, damage, knockback, player.whoAmI);
        //     Projectile.NewProjectile(source , position, velocity, 1, damage, knockback, player.whoAmI);
        //     Projectile.NewProjectile(source , position, velocity, 1, damage, knockback, player.whoAmI);
        //     return false;
        // }
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                .AddIngredient(ItemID.DirtBlock, 5)
                .Register();
        }
    }
}