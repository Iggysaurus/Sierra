using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
	public class Afterburner : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Changes normal arrows to explosive magma arrows");
		}

		public override void SetDefaults()
		{
			item.damage = 21;
			item.ranged = true;
			item.width = 28;
			item.height = 50;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; 
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Arrow;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) 
			{
				type = mod.ProjectileType("VV2Arrow");
			}
		   return true;
		}
	}
}