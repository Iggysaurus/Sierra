using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc.Runes
{
	public class PossessiveEnchantment : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Possessive Enchantment");
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
			myplayer.PossessiveOne = true;
            return true;
		}
	}
}
