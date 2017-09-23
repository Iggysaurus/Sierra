using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace Sierra.Projectiles
{
    public class BeamLazer : ModProjectile
    {
 
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
            projectile.friendly = true;
			projectile.magic = true;
			projectile.scale = 1f;
            projectile.timeLeft = 600;
			projectile.extraUpdates = 2;
			projectile.tileCollide = false;
        }
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beam Lazer");
        } 
        public override void AI()
        {
		    if (Main.rand.Next(5) == 0)
            {
                int index = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67);
                Main.dust[index].position = projectile.Center;
                Main.dust[index].velocity *= 0.2f;
                Main.dust[index].noGravity = true;
                Main.dust[index].scale = 1f;
            }
	    }
		public override Color? GetAlpha(Color lightColor) 
        {
            return Color.White;
        }
		public override void Kill(int timeLeft)
        {
            for(int i=0; i<45; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;
            }
        }
    }
}