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
        //This mod item is a magic weapon that utilizes the STRATEGY pattern to assign different projectile algorithms 
        // to the weapon attacks every time it is fired, based on random number generation
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
        //STRATEGY PATTERN PART!!
        //This randomly assigns one of the modded projectiles I created, each with unique algorithms, every time the player
        // uses this weapon. See the Content/Projectiles/Weapons filepath for the projectile code themselves. (Big boulder, Spectral bolt)
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