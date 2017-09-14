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
            item.damage = 120;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.knockBack = 3;
            item.value = 6700;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Arrow;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.WoodenArrowFriendly, damage, knockBack, player.whoAmI, 0f, 0f); 
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 10);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .33f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(8, 0);
        }
    }
}

