using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class VV2Explosion : ModProjectile
    {
        public override void SetDefaults() 
        {
            projectile.width = 60;
            projectile.height = 60;
            projectile.ranged = true;
            projectile.penetrate = 999;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 0;
            projectile.timeLeft = 20;
			Main.projFrames[projectile.type] = 1;
        }
		
        public override void AI()
        {
            if (projectile.localAI[0] == 0f) 
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
                projectile.localAI[0] = 1f;
            }
			for (int i = 0; i < 2; i++)
			{
				int DustID2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[DustID2].noGravity = true;
			}
        }
		
		
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}		
    }
}