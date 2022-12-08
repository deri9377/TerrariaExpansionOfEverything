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
    internal class ScorchBullet : ModItem
    {
        //THIS IS A DECORATOR CLASS FOR RANGED WEAPON OBJECTS
        //This is a custom ITEM class for the ScorchBullet
        //The scorch bullet is a medium velocity flame round that sets targets on fire
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scorch Round");
            Tooltip.SetDefault("Crispy mmmmmmm");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // Item.staff[Item.type] = true;
        }
        public override void SetDefaults()
        {

            Item.width = 40;
            Item.height = 40;
            Item.sellPrice(gold: 1);
            Item.value = 25;
            Item.maxStack = 9999;
            Item.consumable = true;
            
            
            Item.damage = 55;
            Item.knockBack = 50f;
            Item.ammo = AmmoID.Bullet;
            Item.rare = ItemRarityID.Master;
    
            // Tool Zone
            Item.shoot = ModContent.ProjectileType<ScorchRounds>();
            Item.shootSpeed = 25f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 0);
        }
    }
}