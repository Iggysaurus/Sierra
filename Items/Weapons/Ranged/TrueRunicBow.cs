using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
    public class TrueRunicBow : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Runic Bow");
			Tooltip.SetDefault("placeholder code");
		}
        
		public override void SetDefaults()
        {
            item.damage = 240;
            item.noMelee = true;
            item.ranged = true;
            item.width = 89;
            item.height = 60;
            item.useTime = 10;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 3;
            item.knockBack = 5;
            item.value = 6700;
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 7f;
			item.useAmmo = AmmoID.Arrow;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.WoodenArrowFriendly, damage, knockBack, player.whoAmI, 0f, 0f); 
            return false;
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .50f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
    }
}

