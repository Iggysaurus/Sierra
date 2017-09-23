using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc
{
    public class BlankRune : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blank Rune");
			Tooltip.SetDefault("Can be used to seal power within it");
		}
		
		public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 99;
            item.value = 130;
            item.rare = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 30);
            recipe.AddIngredient(ItemID.FallenStar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

}