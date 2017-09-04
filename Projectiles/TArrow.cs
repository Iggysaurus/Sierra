using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class TArrow : ModProjectile 
    {
		public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Tar Arrow");
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
            projectile.light = 0.10f; 
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
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 62);
            Main.dust[dust].velocity /= 10f;  //this modify the velocity of the first dust
            Main.dust[dust].scale = 1f;  //this modify the scale of the first dust
			Main.dust[dust].noGravity = true;
		}
		public override void Kill(int timeLeft)
        {
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 62, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f);
		}
    }
}