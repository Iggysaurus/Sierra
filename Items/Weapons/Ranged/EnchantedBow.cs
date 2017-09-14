using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Ranged
{
    public class EnchantedBow : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Bow");
			Tooltip.SetDefault("Changes all arrows to jester's arrows");
		}
        
		public override void SetDefaults()
        {
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.knockBack = 2;
            item.value = 3600;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 5f;
			item.useAmmo = AmmoID.Arrow;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.WoodenArrowFriendly) 
			{
				type = ProjectileID.JestersArrow;
			}
		   return true;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedEssence", 3);
            recipe.SetResult(this);
            recipe.AddTile(TileID.Anvils);
            recipe.AddRecipe();
        }

        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() > .10f;
        }

        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
    }
}

