using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Drops
{
    public class TarBall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tar Ball");
			Tooltip.SetDefault("'Can be used to make various tar items'");
		}
		
		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.rare = 2;
		}
	}
}    