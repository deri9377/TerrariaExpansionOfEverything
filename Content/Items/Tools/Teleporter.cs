using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaExpansionOfEverything.Content.Items.Tools;

public class Teleporter : ModItem {

    public override void SetStaticDefaults() {
        DisplayName.SetDefault("Teleporter");
        Tooltip.SetDefault("Click somewhere to teleport!");

    }

    public override bool? UseItem(Player player) {
        player.Teleport(Main.MouseWorld);
        return true;
    }

    public override void SetDefaults() {
        Item.width = 32;
        Item.height = 32;

        Item.useStyle = TeleportationStyleID.Portal;
    }
}