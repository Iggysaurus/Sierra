using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.NPCs
{
    public class TarSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tar Slime");
			Main.npcFrameCount[npc.type] = 2;
		}


		public override void SetDefaults()
		{
			npc.lifeMax = 60;
			npc.damage = 17;
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
			npc.lifeMax = npc.lifeMax * 1;
			npc.damage = npc.damage * 1;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = Main.tile[x, y].type;
			return spawnInfo.player.ZoneDesert ? 0.80f : 0;
		}
		public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
              				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 14f;
				direction.Y *= 14f;
				
				int amountOfProjectiles = Main.rand.Next(2, 3);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
						float A = (float)Main.rand.Next(-150, 150) * 0.01f;
						float B = (float)Main.rand.Next(-150, 150) * 0.01f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("TarBallProj"), 8, 1, Main.myPlayer, 0, 0);
				}
   		    }
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
		}
	}
}