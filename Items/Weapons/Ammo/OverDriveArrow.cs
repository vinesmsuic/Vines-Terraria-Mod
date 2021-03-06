﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace VinesMod.Items.Weapons.Ammo
{
    public class OverDriveArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("OverDrive Arrow");
            Tooltip.SetDefault("Provide power for OverDrive Weapons.");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.ranged = true;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1.5f;
            item.value = 10;
            item.rare = 6;
            item.shoot = mod.ProjectileType("OverDriveArrow");
            item.shootSpeed *= 1.1f;
            item.ammo = item.type;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	
			recipe.AddIngredient(ItemID.Ruby, 5);
            recipe.AddRecipeGroup("Wood", 15);
            recipe.AddIngredient(mod, "ShardRed", 15);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this, 333);
			recipe.AddRecipe();
		}
    }
}
