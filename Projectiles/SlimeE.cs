using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class SlimeE : ModProjectile
    {
        public override void SetDefaults() 
        {
            projectile.width = 90;
            projectile.height = 90;
            projectile.ranged = true;
            projectile.penetrate = 999;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 0;
            projectile.timeLeft = 20;
			Main.projFrames[projectile.type] = 7;
        }
		
		public override bool PreDraw(SpriteBatch sb, Color lightColor)
        {
            projectile.frameCounter++; 
            if (projectile.frameCounter >= 1) 
            {
                projectile.frame++; 
                projectile.frameCounter = 0; 
            }
            return true;
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
				int DustID2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[DustID2].noGravity = true;
			}
        }
		
		
		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}		
    }
}