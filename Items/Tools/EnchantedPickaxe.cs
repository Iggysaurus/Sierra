using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Tools
{
    public class EnchantedPickaxe : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Pickaxe");
			Tooltip.SetDefault("'Filled with spiritual power!'");
		}
		
		public override void SetDefaults()
        {
            item.damage = 9;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 20;
            item.useAnimation = 20;
            item.pick = 60;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 160;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.useTurn = true;
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