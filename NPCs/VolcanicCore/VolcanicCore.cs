using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.NPCs.VolcanicCore
{
    public class VolcanicCore : ModNPC
    {
		int timer;
		bool createdArena = false;
		Rectangle rect;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcanic Core");
			Main.npcFrameCount[npc.type] = 1;
		}
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 13500;
            npc.damage = 23;
            npc.defense = 7;
            npc.knockBackResist = 0f;
            npc.width = 40;
            npc.height = 40;
            npc.value = Item.buyPrice(0, 1, 0, 0);
            npc.npcSlots = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1; //57 //20
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[24] = true;
            npc.netAlways = true;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
        }

        public override void AI()
        {
			//targeting
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			
			// arena shit
				Rectangle rect = new Rectangle((int)npc.Center.X - 1000, (int)npc.position.Y + 1000, 2000, 2000);
			for(int x = rect.X; x < rect.X + 2000; x+=10)
			{
				int num250 = Dust.NewDust(new Vector2(x, rect.Y), npc.width, npc.height, 258, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
				Main.dust[num250].noGravity = true;
				Main.dust[num250].velocity *= 0f;
				//Main.dust[num250].timeLeft = 1;
			}
			for(int x = rect.X; x < rect.X + 2000; x+=10)
			{
				int num250 = Dust.NewDust(new Vector2(x, rect.Y - 2000), npc.width, npc.height, 258, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
				Main.dust[num250].noGravity = true;
				Main.dust[num250].velocity *= 0f;
				//Main.dust[num250].timeLeft = 1;
			}
			for(int y = rect.Y; y > rect.Y - 2000; y-=10)
			{
				int num250 = Dust.NewDust(new Vector2(rect.X, y), npc.width, npc.height, 258, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
				Main.dust[num250].noGravity = true;
				Main.dust[num250].velocity *= 0f;
				//Main.dust[num250].timeLeft = 1;
			}
			for(int y = rect.Y; y > rect.Y - 2000; y-=10)
			{
				int num250 = Dust.NewDust(new Vector2(rect.X + 2000, y), npc.width, npc.height, 258, (float)(npc.direction * 2), 0f, 158, new Color(53f, 67f, 253f), 1.3f);
				Main.dust[num250].noGravity = true;
				Main.dust[num250].velocity *= 0f;
				//Main.dust[num250].timeLeft = 1;
			}
			if (player.Center.Y > npc.Center.Y + 1000 || player.Center.Y < npc.Center.Y - 1000 || player.Center.X > npc.Center.X + 1000 || player.Center.X < npc.Center.X - 1000)
			{
				player.GetModPlayer<MyPlayer>(mod).ackFire = true;
				//debuff with lots of fire if you leave arena, needs spriting
			}
			else{
				player.GetModPlayer<MyPlayer>(mod).ackFire = false;
			}
			
			//attacks
			if (npc.ai[2] == 0) //readying magma attack
			{
				for (int i = 0; i < 5; i++)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MagmaBall"), ai0: npc.whoAmI, ai1: 72 * i); // change to 5
                    npc.ai[3]++;
                }
				timer = 300;
				npc.ai[2] = 1;
			}
			if (npc.ai[2] == 1) //magma attack evasion
			{
				timer--;
				if (npc.position.Y > Main.player[npc.target].position.Y - 100)
				{
					if (npc.velocity.Y > -1f)
						npc.velocity.Y = npc.velocity.X - 0.75f;
					if (npc.velocity.Y > -3f && npc.velocity.Y < 0f)
					{
						npc.velocity.Y *= 1.03f;
					}
					if (npc.velocity.Y < -3f)
					{
						npc.velocity.Y = -3f;
					}
				}
				if (npc.position.Y < Main.player[npc.target].position.Y - 100)
				{
					if (npc.velocity.Y < 1f)
						npc.velocity.Y = npc.velocity.Y + 0.75f;
					if (npc.velocity.Y < 3f && npc.velocity.Y > 0f)
					{
						npc.velocity.Y *= 1.03f;
					}
					if (npc.velocity.Y > 3f)
					{
						npc.velocity.Y = 3f;
					}
				}
				if (npc.position.X > Main.player[npc.target].position.X)
				{
					if (npc.velocity.X > -1f)
						npc.velocity.X = npc.velocity.X - 0.75f;
					if (npc.velocity.X > -3f && npc.velocity.X < 0f)
					{
						npc.velocity.X *= 1.03f;
					}
					if (npc.velocity.X < -3f)
					{
						npc.velocity.X = -3f;
					}
				}
				if (npc.position.X < Main.player[npc.target].position.X)
				{
					if (npc.velocity.X < 1f)
						npc.velocity.X = npc.velocity.X + 0.75f;
					if (npc.velocity.X < 3f && npc.velocity.X > 0f)
					{
						npc.velocity.X *= 1.03f;
					}
					if (npc.velocity.X > 3f)
					{
						npc.velocity.X = 3f;
					}
				}
				if (npc.ai[3] <= 0)
				{
					
				}
				if (timer <= 0)
				{
					timer = 400;
					npc.ai[2] = 2;
				}
			}
			if (npc.ai[2] == 2) //Chases you down this time not going above you but towards you. Hell do his stalagmites a little bittle.
			{
				timer--;
				if (timer % 100 == 0)
				{
					if (Main.rand.Next(2) == 0) //right stalagmite
					{
						for (int y = rect.Y; y > rect.Y - 2000; y -= 100)
						{
							Projectile.NewProjectile(rect.X, y, 5f, 0, mod.ProjectileType("MoltenStalagmite"), 25, 1, Main.myPlayer, 0, 0);
						}
					}
					else //left stalagmite
					{
						for (int y = rect.Y; y > rect.Y - 2000; y -= 100)
						{
							Projectile.NewProjectile(rect.X + 2000, y, -5f, 0, mod.ProjectileType("MoltenStalagmite"), 25, 1, Main.myPlayer, 0, 0);
						}
					}
				}
				if (npc.position.Y > Main.player[npc.target].position.Y)
				{
					if (npc.velocity.Y > -1f)
						npc.velocity.Y = npc.velocity.X - 0.75f;
					if (npc.velocity.Y > -3f && npc.velocity.Y < 0f)
					{
						npc.velocity.Y *= 1.03f;
					}
					if (npc.velocity.Y < -3f)
					{
						npc.velocity.Y = -3f;
					}
				}
				if (npc.position.Y < Main.player[npc.target].position.Y)
				{
					if (npc.velocity.Y < 1f)
						npc.velocity.Y = npc.velocity.Y + 0.75f;
					if (npc.velocity.Y < 3f && npc.velocity.Y > 0f)
					{
						npc.velocity.Y *= 1.03f;
					}
					if (npc.velocity.Y > 3f)
					{
						npc.velocity.Y = 3f;
					}
				}
				if (npc.position.X > Main.player[npc.target].position.X)
				{
					if (npc.velocity.X > -1f)
						npc.velocity.X = npc.velocity.X - 0.75f;
					if (npc.velocity.X > -3f && npc.velocity.X < 0f)
					{
						npc.velocity.X *= 1.03f;
					}
					if (npc.velocity.X < -3f)
					{
						npc.velocity.X = -3f;
					}
				}
				if (npc.position.X < Main.player[npc.target].position.X)
				{
					if (npc.velocity.X < 1f)
						npc.velocity.X = npc.velocity.X + 0.75f;
					if (npc.velocity.X < 3f && npc.velocity.X > 0f)
					{
						npc.velocity.X *= 1.03f;
					}
					if (npc.velocity.X > 3f)
					{
						npc.velocity.X = 3f;
					}
				}
				if (timer <= 0)
				{
					timer = 40;
					npc.ai[2] = 4;
				}
			}
			if (npc.ai[2] == 4)
			{
				timer--;
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
				if (timer % 9 == 0)
				{
					Vector2 placePosition = npc.Center;
				Vector2 direction = Main.player[npc.target].Center - placePosition;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("MoltenStalagmite"), 30, 1, Main.myPlayer, 0, 0);
				}
				if (timer <= 0)
				{
					timer = 0;
					npc.ai[2] = 0;
				}
			}
		}
    }
}

