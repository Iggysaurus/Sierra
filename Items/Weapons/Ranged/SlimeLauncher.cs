using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
	public class SlimeLauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots exploding slime balls");
		}

		public override void SetDefaults()
		{
			item.damage = 52;
			item.ranged = true;
			item.width = 52;
			item.height = 22;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 7;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("SlimeShot");
			item.shootSpeed = 9f;
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
	}
}