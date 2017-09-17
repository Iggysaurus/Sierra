using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Misc.RuneScrolls
{
	public class ScrolloftheFireWarrior : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll of the Fire Warrior");
			Tooltip.SetDefault("permanently increases critical damage and defense by a small amount");
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
			myplayer.FireWarrior = true;
            return true;
		}
	}
}
