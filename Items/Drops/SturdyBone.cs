using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Drops
{
    public class SturdyBone : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sturdy Bone");
			Tooltip.SetDefault("'Can be used to make various items'");
		}
		
		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.maxStack = 999;
			item.rare = 2;
		}
	}
}    