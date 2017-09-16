using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class TrueArrow1 : ModProjectile 
    {
		public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("True Arrow");
        }
        public override void SetDefaults()
        {
            projectile.width = 10; 
            projectile.height = 32; 
            projectile.aiStyle = 1; 
            projectile.friendly = true; 
            projectile.tileCollide = true; 
            projectile.magic = true;   
            projectile.timeLeft = 1000;
            projectile.light = 0.20f; 
			projectile.extraUpdates = 0;
			projectile.scale = 1f;
            aiType = ProjectileID.WoodenArrowFriendly;		
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 58);
            Main.dust[dust].velocity /= 10f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
			Main.dust[dust].noGravity = true;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		public override void Kill(int timeLeft)
        {
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("TrueBoom1"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
            for (int k = 0; k < 5; k++)
            {
            	Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 58, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
		}
    }
}