using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Sierra.Projectiles
{
    public class AshBoomerangProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(106);
            aiType = 106;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ash Boomerang");
        }
		
		public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
            Main.dust[dust].velocity /= 10f;  
            Main.dust[dust].scale = 1f;  
			Main.dust[dust].noGravity = true;
		}
    }
}
