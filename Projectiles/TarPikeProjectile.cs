using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Projectiles
{
    public class TarPikeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tar Spear");
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1.3f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.alpha = 0;
        }
        public float movementFactor
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }
        public override void AI()
        {
            Player projOwner = Main.player[projectile.owner];
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            if (!projOwner.frozen)
            {
                if (movementFactor == 0f)
                {
                    movementFactor = 3f;
                    projectile.netUpdate = true;
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3)
                {
                    movementFactor -= 2.4f;
                }
                else
                {
                    movementFactor += 3f;
                }
            }
            projectile.position += projectile.velocity * movementFactor;
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + MathHelper.ToRadians(135f);
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            if (Main.rand.Next(3) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 2, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default(Color), 1.2f);
                Main.dust[dustIndex].velocity += projectile.velocity * 0.3f;
                Main.dust[dustIndex].velocity *= 0.2f;
            }
            if (Main.rand.Next(4) == 0)
            {
                int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 2, 0f, 0f, 254, default(Color), 0.3f);
                Main.dust[dustIndex].velocity += projectile.velocity * 0.5f;
                Main.dust[dustIndex].velocity *= 0.5f;
                return;
            }
        }
    }
}
