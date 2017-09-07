using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Sierra.Projectiles
{

    public class TarBallProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tar Ball");
        }
        public override void SetDefaults()
        {
			            projectile.CloneDefaults(ProjectileID.SpikyBall);
            projectile.hostile = hostile;
            projectile.hostile = true;
            projectile.width = 14;
            projectile.height = 14;
            projectile.friendly = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;

        }
        public override bool PreAI()
        {
			projectile.rotation += 0.1f;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 14, 0f, 0f);
            Main.dust[dust].noGravity = true;
            return true;
        }
         public override void Kill(int timeLeft)
        {
            for (int num621 = 0; num621 < 5; num621++)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 14, 0f, 0f);
            }
        }
    }
}

