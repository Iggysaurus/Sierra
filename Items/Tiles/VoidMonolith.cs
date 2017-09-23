using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tiles
{
    public class VoidMonolith : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Monolith");
            Tooltip.SetDefault("'It glows of darkness'");
        }
		
		public override void SetDefaults()
        {
            item.width = 44;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("VoidMonolith"); 
        }
  
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MoltenChunk", 2);
			recipe.AddIngredient(null, "MonolithOrb", 1);
            recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
