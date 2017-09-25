using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Accessories
{
	public class BoneToken : ModItem
	{
		 public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Token");
            Tooltip.SetDefault("Increases defense by 1 \nIncreases minion damage");
        }    
		
		public override void SetDefaults()
		{
            item.width = 28;
			item.height = 28;
            item.value = 10000;
			item.rare = 4;
			item.defense = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionDamage += 0.05f;
		}
	}
}
