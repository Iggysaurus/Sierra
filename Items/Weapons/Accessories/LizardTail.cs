using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Accessories
{
	public class LizardTail : ModItem
	{
		 public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lizard Tail");
            Tooltip.SetDefault("Increases mana crystals by 2 \nIncreases magic damage \nNo knockback");
        }    
		
		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 28;
            item.value = 10000;
			item.rare = 4;
			item.defense = 1;
			item.accessory = true;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.10f;
			player.noKnockback = true;
		}
	}
}
