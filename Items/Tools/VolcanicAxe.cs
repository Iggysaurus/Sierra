using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tools
{
    public class VolcanicAxe : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcanic Axe");
			Tooltip.SetDefault("'You can feel it boiling!'");
		}
		
		public override void SetDefaults()
        {
            item.damage = 14;
            item.melee = true;
            item.width = 46;
            item.height = 34;
            item.useTime = 22;
            item.useAnimation = 22;
            item.axe = 80;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 1600;
            item.rare = 7;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MoltenChunk", 18);
			recipe.AddIngredient(null, "AshStone", 12);
            recipe.AddTile(TileID.Anvils); 
            recipe.SetResult(this);  
            recipe.AddRecipe();
        }
    }
}