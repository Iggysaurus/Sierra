using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
    public class RunicBow : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Bow");
			Tooltip.SetDefault("A bow of a fallen champion... Appears to be broken");
		}
        
		public override void SetDefaults()
        {
            item.damage = 30;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.shoot = 3;
            item.knockBack = 3;
            item.value = 6700;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Arrow;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TrueArrow2"), damage, knockBack, player.whoAmI, 0f, 0f);
			
			int numberProjectiles = 2 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; 
		}
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .5f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }
    }
}

