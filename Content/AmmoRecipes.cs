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

//This is part of a factory for creating recipes for all of the modded items we have created
//It works be being called by our ModSystem with a filepath variable for the item.
//Currently for testing sake, it generates recipes for the Sharpshooter and Scorch type bullet objects so that
//we can craft them each using 1 dirt block item
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
            Recipe newRecipe2 = Recipe.Create(ModContent.ItemType<ScorchBullet>(), 200);
            newRecipe2.AddIngredient(ItemID.DirtBlock, 1);
            newRecipe2.Register();
        }
    }
}