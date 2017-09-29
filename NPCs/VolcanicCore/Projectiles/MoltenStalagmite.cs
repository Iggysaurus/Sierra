using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.NPCs.VolcanicCore.Projectiles
{

    public class MoltenStalagmite : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magma Stalagma");
		}
        public override void SetDefaults()
        {  //projectile name
            projectile.width = 20;       //projectile width
            projectile.height = 28;  //projectile height
            projectile.friendly = false;     //make that the projectile will not damage you
			projectile.hostile = true;
            projectile.melee = true;         // 
            projectile.tileCollide = true;   //make that the projectile will be destroed if it hits the terrain
            projectile.penetrate = 1;      //how many npc will penetrate
            projectile.timeLeft = 500;   //how many time projectile projectile has before disepire
            projectile.light = 0.75f;    // projectile light
			projectile.alpha = 0;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }
        public override void AI()          
        {                                                           // |
             int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 258, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].scale = 1.4f;
            Main.dust[dust].noGravity = true;
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
    }
}