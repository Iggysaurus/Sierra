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
    public class VolcanicBat : ModNPC
    {
		private int ShootTimer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Bat");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CaveBat];
        }
        public override void SetDefaults()
        {
            npc.width = 54;
            npc.height = 48;
            npc.damage = 26;
            npc.defense = 10;
            npc.lifeMax = 87;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath4;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 14;
            aiType = NPCID.CaveBat;
            animationType = NPCID.CaveBat;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			Player player = spawnInfo.player;
			return spawnInfo.player.GetModPlayer<MyPlayer>(mod).ZoneVolcano ? 4f : 0f;
        }

       public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            
            target.AddBuff(BuffID.OnFire, 180, true);
           
        }
		public override void AI()
        {
			int dust = Dust.NewDust(new Vector2(npc.Center.X, npc.Center.Y), 20, 20, 258);
			ShootTimer++;
			if (ShootTimer >= 180)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("VolcanicSlimeShot"), npc.damage, 1, Main.myPlayer, 0, 0);
				
				ShootTimer = 0;
			}
		}

       

	}
}
