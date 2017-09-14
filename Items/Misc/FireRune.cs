using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc
{
    public class FireRune : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fire Rune");
			Tooltip.SetDefault("An ancient creator sealed his power within this stone");
		}
		
		public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 99;
            item.value = 1030;
            item.rare = 3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 3);
            recipe.AddIngredient(ItemID.Obsidian, 6);
            recipe.AddIngredient(null, "BlankRune", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }

}