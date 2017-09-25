using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc
{
    public class PossessiveOrb : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessive Orb");
			Tooltip.SetDefault("Powers of great extent remain in this orb... /nGather 3 of these to boost your health or other stats");
		}
		
		public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 10;
            item.value = 50000;
            item.rare = 11;
        }
    }
}