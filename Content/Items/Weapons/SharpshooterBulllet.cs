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
    internal class SharpshooterBullet : ModItem
    {
        //THIS IS A DECORATOR CLASS FOR THE RANGED WEAPON OBJECTS
        //This is a custom ITEM class for the Sharpshooter Bullet
        //The Sharpshooter bullet is a high velocity, high damage ranged bullet
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sharpshooter Round");
            Tooltip.SetDefault("They never saw it coming.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        //Item stats
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.sellPrice(gold: 1);
            Item.value = 25;
            Item.maxStack = 9999;
            Item.consumable = true;
            
            
            Item.damage = 400;
            Item.knockBack = 50f;
            Item.ammo = AmmoID.Bullet;
            Item.rare = ItemRarityID.Master;
    
            // Tool Zone
            Item.shoot = ModContent.ProjectileType<SharpshooterRounds>();
            Item.shootSpeed = 25f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 0);
        }
    }
}