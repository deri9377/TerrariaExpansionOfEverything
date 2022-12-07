using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaExpansionOfEverything.Content.Items;

public class GeodudeItem : ModItem
{
	public override void SetStaticDefaults() {
		DisplayName.SetDefault("ExampleMount Car key");
		Tooltip.SetDefault("This summons a modded mount.");

		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
	}

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