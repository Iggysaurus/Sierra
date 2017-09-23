using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc
{
    public class BlankScroll : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blank Scroll");
			Tooltip.SetDefault("Can be used to create a brand new rune scrolls");
		}
		
		public override void SetDefaults()
        {
            item.width = 20;
            item.height = 38;
            item.maxStack = 999;
            item.value = 130;
            item.rare = 1;
        }
    }

}