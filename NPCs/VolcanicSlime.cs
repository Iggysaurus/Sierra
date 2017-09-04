using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace Sierra.NPCs
{
    public class VolcanicSlime : ModNPC
	{
		private int ShootTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Volcanic Slime");
			Main.npcFrameCount[npc.type] = 2;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 120;
			npc.damage = 22;
			npc.defense = 5;
			npc.width = 34;
			npc.height = 28;
			npc.aiStyle = 1;
			npc.knockBackResist = 0f;
			animationType = 81;
			npc.npcSlots = 1f;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath4;
			npc.value = Item.buyPrice(0, 0, 7, 8);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = Convert.ToInt32(npc.lifeMax * 1.3);
			npc.damage = Convert.ToInt32(npc.damage * 1.3);
		}
		public override void AI()
        {
			int dust = Dust.NewDust(new Vector2(npc.Center.X, npc.Center.Y), 20, 20, 258);
			ShootTimer++;
			if (ShootTimer >= 180)
			{
				int i;
				float spread = 30f * 0.0174f;
				double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y)- spread/2;
				double deltaAngle = spread/8f;
				double offsetAngle;
				
				for (i = 0; i < 4; i++ )
				{
					offsetAngle = (startAngle + deltaAngle * ( i + i * i ) / 2f ) + 32f * i;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)( Math.Sin(offsetAngle) * 5f ), (float)( Math.Cos(offsetAngle) * 5f ), mod.ProjectileType("VolcanicSlimeShot"), npc.damage, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)( -Math.Sin(offsetAngle) * 5f ), (float)( -Math.Cos(offsetAngle) * 5f ), mod.ProjectileType("VolcanicSlimeShot"), npc.damage, 0f, Main.myPlayer, 0f, 0f);
				}
				
				ShootTimer = 0;
			}
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(BuffID.OnFire, 180, true);
            }
        }
		
		/*public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return spawnInfo.player.ZoneDesert ? 0.80f : 0;
		}
		
		public override void NPCLoot()
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(npc.position.X + npc.width / 2) / 16;
				int centerY = (int)(npc.position.Y + npc.height / 2) / 16;
				int halfLength = npc.width / 2 / 16 + 1;

				if (Main.rand.Next(8) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TarBall"), Main.rand.Next(4, 5));
				}
			}
		}*/
	}
}