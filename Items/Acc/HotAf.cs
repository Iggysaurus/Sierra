using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Sierra;
using Terraria.ModLoader;

namespace Sierra.Items.Acc
{
    public class HotAf : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Superheated Crystal");
			Tooltip.SetDefault("Damage taken reflects back into an explosion");
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
