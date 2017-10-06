using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc.Runes
{
	public class ConjuringEnchantment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Conjuring Enchantment");
			Tooltip.SetDefault("permanently increases health by 2 hearts");
		}
		public override void SetDefaults()
		{
			item.consumable = true;
			item.useStyle = 2;
			item.maxStack = 1;
		}
		public override bool UseItem(Player player)
		{        
            MyPlayer myplayer = (MyPlayer)(player.GetModPlayer(mod, "MyPlayer"));
			myplayer.PossessiveTwo = true;
            return true;
		}
	}
}
