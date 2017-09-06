using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace Sierra.Items.Weapons.Melee
{
    public class TarSlicer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tar Slicer");
        }
        public override void SetDefaults()
        {
            item.damage = 14;
            item.melee = true;
            item.width = 46;
            item.height = 46;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 2000;
            item.rare = 2;
            item.UseSound = SoundID.Item18;
            item.autoReuse = true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "TarBall", 12);
			recipe.AddIngredient(null, "SturdyBone", 3);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(player.position, player.width,player.height, 62);
			}
		}

	}
}