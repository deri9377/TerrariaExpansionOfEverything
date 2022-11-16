using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TerrariaExpansionOfEverything.Content.Items.Tools
{
    internal class MegaRod : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Moncher of Ram");
            Tooltip.SetDefault("Can we get much higher?");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 64;


            Item.useTime = 20;
            Item.useAnimation = 20;
            

            Item.value = Item.buyPrice(copper: 5);
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            // Item.useTurn = true;


            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.damage = 10;
            Item.knockBack = 100f;


            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.DD2_GoblinBomberScream;


            // Tool Zone
            Item.fishingPole = 50;
            Item.shoot = ProjectileID.BobberGolden;
            Item.shootSpeed = 16f;
            
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Item.fishingPole > 0){
                for(int i = 0; i < 1000000; i++){
                     Projectile.NewProjectile(source , position, velocity + new Vector2(Main.rand.Next(5)), type, damage, knockback, player.whoAmI);
                }
            
            return false;
            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);

        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            CreateRecipe()
                .AddIngredient(RecipeGroupID.Wood, 5)
                .Register();
        }
    }
}