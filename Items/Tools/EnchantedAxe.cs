using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tools
{
    public class EnchantedAxe : ModItem
    {
         public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Axe");
			Tooltip.SetDefault("'Filled with spiritual power!'");
		}
		
		public override void SetDefaults()
        {
            item.damage = 2;
            item.melee = true;
            item.width = 32;
            item.height = 26;
            item.useTime = 25;
            item.useAnimation = 25;
            item.axe = 10;   
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 160;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EnchantedEssence", 4);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}