using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Drops
{
    public class GraniteElement : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Element");
			Tooltip.SetDefault("Used to create various granite items");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
		}
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 22;
            item.rare = 4;
            item.value = Item.sellPrice(0, 0, 1, 0);
        }
    }
}
