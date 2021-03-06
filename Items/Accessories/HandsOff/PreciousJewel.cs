using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Accessories.HandsOff
{
	public class PreciousJewel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Precious Jewel");
			Tooltip.SetDefault("immune most debuffs when you have less than 100 mana.");
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = Item.sellPrice(gold: 2); 
			item.rare = 6;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.statMana < 100)
			{
				player.buffImmune[BuffID.Frozen] = true;
				player.buffImmune[BuffID.Chilled] = true;
				player.buffImmune[BuffID.Frostburn] = true;
				player.buffImmune[BuffID.Poisoned] = true;
				player.buffImmune[BuffID.Darkness] = true;
				player.buffImmune[BuffID.OnFire] = true;
				player.buffImmune[BuffID.Cursed] = true;
				player.buffImmune[BuffID.Bleeding] = true;
				player.buffImmune[BuffID.Confused] = true;
				player.buffImmune[BuffID.Slow] = true;
				player.buffImmune[BuffID.Weak] = true;
				player.buffImmune[BuffID.Silenced] = true;
				player.buffImmune[BuffID.BrokenArmor] = true;
				player.buffImmune[BuffID.Ichor] = true;
				player.buffImmune[BuffID.Venom] = true;
				player.buffImmune[BuffID.Weak] = true;
				player.buffImmune[BuffID.Blackout] = true;
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "BloodStone", 1);
			recipe.AddIngredient(mod, "IcySteel", 1);
			recipe.AddIngredient(mod, "ShardWhite", 20);
			recipe.AddIngredient(mod, "ShardRed", 40);
			recipe.AddIngredient(mod, "ShardBlue", 40);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}