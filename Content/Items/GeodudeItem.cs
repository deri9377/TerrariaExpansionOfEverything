using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

//This is a custom pet item class that allows us to create a Mountable Geodude. 
//This part of the project is dedicated to our amazing friend and EMT, Brandon "Amazing at Siege" Brando. He loves geodude. 
namespace TerrariaExpansionOfEverything.Content.Items;

public class GeodudeItem : ModItem
{
	public override void SetStaticDefaults() {
		DisplayName.SetDefault("ExampleMount Car key");
		Tooltip.SetDefault("This summons a modded mount.");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}
//stats for usage of the spritemesh created for geodude
	public override void SetDefaults() {
		Item.width = 20;
		Item.height = 30;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.useStyle = ItemUseStyleID.Swing; // how the player's arm moves when using the item
		Item.rare = ItemRarityID.Green;
		Item.UseSound = SoundID.Item79; // What sound should play when using the item
		Item.noMelee = true; // this item doesn't do any melee damage
		Item.mountType = ModContent.MountType<Mounts.Geodude>();
	}

}