using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.NPCs.VolcanicCore
{
    public class MagmaBall : ModNPC
    {
        private NPC parent { get { return Main.npc[(int)npc.ai[0]]; } set { npc.ai[0] = value.whoAmI; } }
        private float rotate { get { return npc.ai[1]; } set { npc.ai[1] = value; } }
		int timer = 300;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Magma");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 175;
            npc.damage = 23;
            npc.knockBackResist = 0f;
            npc.width = 34;
            npc.height = 54;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = false;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;

            npc.netAlways = true;
        }

        public override void AI()
        {
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 258, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
            Main.dust[dust].scale = 2f;
            Main.dust[dust].noGravity = true;
            Vector2 rotatePosition = Vector2.Transform(new Vector2(-1 * 50, -20), Matrix.CreateRotationZ(MathHelper.ToRadians(rotate))) + parent.Center;
            npc.Center = rotatePosition;

            rotate += .4f;

            if (!parent.active)
                npc.life = 0;
			
			timer--;
			if (timer <= 0)
			{
				Vector2 placePosition = npc.Center;
				Vector2 direction = Main.player[npc.target].Center - placePosition;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MagmaBallProjBoss"), 50, 1, Main.myPlayer, 0, 0);
				npc.life = 0;
			}
        }

        public override bool CheckDead()
        {
            if (npc.life <= 0)
            {
                parent.ai[3]--;
				Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 10);
				for (int k = 0; k < 5; k++)
				{
					Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 258, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
				}
            }
            return true;
        }
    }
    
}
