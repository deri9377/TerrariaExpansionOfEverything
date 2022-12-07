using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TerrariaExpansionOfEverything.Content.Items.Weapons;
using TerrariaExpansionOfEverything.Content.Projectiles.Weapons;
namespace TerrariaExpansionOfEverything.Content;

public class AmmoRecipes
{
    public class AmmoRecipe : ModSystem
    {
        public override void AddRecipes()
        {
            base.AddRecipes();
            Recipe newRecipe = Recipe.Create(ModContent.ItemType<SharpshooterBullet>(), 200);
            newRecipe.AddIngredient(ItemID.DirtBlock, 1);
            newRecipe.Register();
        }
    }
}