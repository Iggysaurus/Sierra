using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
namespace Sierra.Items.Weapons.Magic
{
    public class EvergreenStave : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evergreen Stave");
		}


        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 5;
            item.crit = 4;
            item.mana = 9;
            item.damage = 54;
            item.knockBack = 3;
            item.useStyle = 5;
			item.useAnimation = 40;
			item.useTime = 10;
			item.reuseDelay = 20;
            item.magic = true;
            item.noMelee = true;
            item.autoReuse = true;
            Item.staff[item.type] = true;
            item.shoot = mod.ProjectileType("FireWorkGreen");
            item.shootSpeed = 8f;
            item.UseSound = SoundID.Item20;
        }
        

    }
}
