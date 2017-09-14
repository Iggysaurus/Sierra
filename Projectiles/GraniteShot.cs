using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class GraniteShot : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Granite Shot");
		}
        public override void SetDefaults()
        {  
            projectile.width = 20;      
            projectile.height = 28;  
            projectile.friendly = false;   
			projectile.hostile = true;
            projectile.melee = true;         
            projectile.tileCollide = true;  
            projectile.penetrate = 1;      
            projectile.timeLeft = 200;   
            projectile.light = 0.75f;    
			projectile.alpha = 255;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()          
        {                                                       
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 29, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].scale = 1f;
            Main.dust[dust].noGravity = true;
			
        }
    }
}