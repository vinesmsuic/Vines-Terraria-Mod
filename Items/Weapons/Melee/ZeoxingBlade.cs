using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VinesMod.Items.Weapons.Melee
{
	public class ZeoxingBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zeoxing Blade");
			Tooltip.SetDefault("A Cosmic blade that can wipe out the universe.");
		}
		public override void SetDefaults()
		{
			item.damage = 1500;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.value = 3000000;
			item.rare = -12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<Projectiles.ZeoxingProjectile>();
			item.shootSpeed = 60f; 
			item.scale = 0.75f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 7;
			float rotation = MathHelper.ToRadians(45);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage*5, knockBack, player.whoAmI);
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 15 * 60);
			target.AddBuff(BuffID.Bleeding, 15 * 60);
			target.AddBuff(BuffID.Frozen, 15 * 60);
			target.AddBuff(BuffID.Chilled, 15 * 60);
			target.AddBuff(BuffID.ShadowFlame, 15* 60);
			target.AddBuff(BuffID.Poisoned, 15* 60);
			target.AddBuff(BuffID.Venom, 15* 60);
			target.AddBuff(BuffID.Confused, 15* 60);
			target.AddBuff(BuffID.Ichor, 15* 60);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
	
			recipe.AddIngredient(ItemID.FallenStar, 999);
			recipe.AddIngredient(ItemID.LunarBar, 90);
			recipe.AddIngredient(ItemID.Cloud, 999);
			recipe.AddIngredient(ItemID.RainCloud, 100);
			recipe.AddIngredient(mod, "DarkMatter", 1);
			recipe.AddIngredient(mod, "LightMatter", 1);
			recipe.AddIngredient(mod, "StarForceCannonOverDrive", 1);
			recipe.AddIngredient(mod, "StarWrathOverDrive", 1);
			recipe.AddIngredient(mod, "OverDrivePurple", 5);
			recipe.AddIngredient(mod, "OverDriveRed", 5);
			recipe.AddIngredient(mod, "OverDriveBlue", 5);
			recipe.AddIngredient(mod, "OverDriveWhite", 5);
			recipe.AddIngredient(mod, "OverDriveGreen", 5);
			recipe.AddIngredient(mod, "OverDriveYellow", 5);
			recipe.AddTile(mod.TileType("StarForge"));
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("SparkleYellow"));
			}
		}
	}
}
