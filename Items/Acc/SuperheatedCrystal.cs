using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Acc
{
    public class SuperheatedCrystal : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Superheated Crystal");
			Tooltip.SetDefault("Damage taken reflects back into an explosion");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));
		}
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.rare = 4;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.defense = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<MyPlayer>(mod).boom = true;
		
        }
    }
}
