using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tools
{
    public class EnchantedHammer : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Hammer");
			Tooltip.SetDefault("'Filled with spiritual power!'");
		}
		
		public override void SetDefaults()
        {
            item.damage = 13;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 25;
            item.useAnimation = 25;
            item.hammer = 50;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 100;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedEssence", 3);
            recipe.AddTile(TileID.Anvils);  
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
