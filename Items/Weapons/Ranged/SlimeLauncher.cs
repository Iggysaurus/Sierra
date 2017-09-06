using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;


namespace Sierra.Items.Weapons.Ranged
{
    public class SlimeLauncher : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Launcher");
			Tooltip.SetDefault("Shoots explosive balls of slime");
		}
        public override void SetDefaults()
        {
            item.damage = 36; 
            item.ranged = true;
            item.width = 64;
            item.height = 64;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.knockBack = 3.5f;
            item.value = 100;
            item.rare = 3;
            item.scale = 1f;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.useTurn = false;  
            item.noMelee = true;

            item.shoot = mod.ProjectileType("SlimeShot");
            item.shootSpeed = 10f;
        }
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 0);
		}
    }
}
