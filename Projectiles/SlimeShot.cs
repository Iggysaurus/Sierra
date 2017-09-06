using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
	
    public class SlimeShot : ModProjectile
    {
		private int thing = 5;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Shot");
		}
        public override void SetDefaults()
        {
            projectile.width = 25;
            projectile.height = 25;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.aiStyle = 2;
            projectile.timeLeft = 180;
            aiType = 48;
        }
        
        public override void AI()
        {
        	
            	Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, projectile.velocity.X * 0.15f, projectile.velocity.Y * 0.15f);
           
        }
		 public override bool OnTileCollide(Vector2 oldVelocity)
        {
            thing--;
            if (thing <= 0)
            {
                projectile.Kill();
            }
            else
            {
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -(oldVelocity.X * 2);
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -(oldVelocity.Y / 2);
                }
            }
            return false;
        }
         public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("SlimeE"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 74, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				
            }
			Main.PlaySound(SoundID.Item, projectile.Center, 14);    //bomb explosion sound
			Main.PlaySound(SoundID.Item, projectile.Center, 21);    //swishy sound
        }
    }
}