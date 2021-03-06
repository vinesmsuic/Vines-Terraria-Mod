using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class Claymore : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Claymore");
		}

		public override void SetDefaults()
		{
			item.damage = 25;      
			item.melee = true; 
			item.width = 40; 
			item.height = 40;           
			item.useTime = 20;         
			item.useAnimation = 20; 
			item.useStyle = 1;//The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 7f;
			item.value = Item.sellPrice(copper: 10);           //The value of the weapon
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.scale = 1.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("IronBar", 15);
			recipe.AddIngredient(ItemID.GoldBar, 22);
			recipe.AddIngredient(mod, "ShardWhite", 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
