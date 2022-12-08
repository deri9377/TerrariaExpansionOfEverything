using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

//The super boots are an inheritance class of the default armor class
//that allowed me to create boots that make the player move extremely fast
namespace TerrariaExpansionOfEverything.Content.Items
{
    [AutoloadEquip(EquipType.Legs)]
    internal class SuperBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supa Bootz");
            Tooltip.SetDefault("1 Morbillion% Increased Movement Speed \n Fast as HECK!");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;


            

            Item.value = Item.buyPrice(copper: 5);
            Item.maxStack = 1;
            // Item.useTurn = true;


            Item.defense = 2;

            Item.rare = ItemRarityID.Expert;


            // Tool Zone
            
            
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed = 10f;
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