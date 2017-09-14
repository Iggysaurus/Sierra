using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tools
{
    public class VolcanicPickaxe : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcanic Pickaxe");
			Tooltip.SetDefault("'You can feel it boiling!'");
		}
		
		public override void SetDefaults()
        {
            item.damage = 16;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 20;
            item.useAnimation = 20;
            item.pick = 160;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 1600;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MoltenChunk", 24);
			recipe.AddIngredient(null, "AshStone", 15);
            recipe.AddTile(TileID.Anvils); 
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}