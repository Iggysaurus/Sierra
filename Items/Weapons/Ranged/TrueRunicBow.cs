using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
	public class TrueRunicBow : ModItem
	{
		int shootType = 0;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots a volley of explosive arrows");
		}
	
		public override void SetDefaults()
		{
			item.damage = 54;
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
			item.useAnimation = 12;
			item.useTime = 4;
			item.reuseDelay = 14;
		}
		
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			shootType++;
			if (shootType > 3)
			{
				shootType = 1;
			}
			if (shootType == 1)
			{
				type = mod.ProjectileType("TrueArrow1");
			}
			else if (shootType == 2)
			{
				type = mod.ProjectileType("TrueArrow2");
			}
			else if (shootType == 3)
			{
				type = mod.ProjectileType("TrueArrow3");
			}
		   return true;
		}
	}
}
