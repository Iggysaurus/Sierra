using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace Sierra
{
    public class MyPlayer : ModPlayer
    {
		public int debuffTimer = 0;
		public bool PossessiveOne = false;
		public bool FireWarrior = false;
		public bool ZoneVolcano;
		public bool ackFire = false;
		public bool boom = false;
        public override void ResetEffects()
        {
            boom = false;
        }
		public override void UpdateBiomes()
		{
			ZoneVolcano = (SierraWorld.volcanoTiles > 50);
		}
		public override void UpdateBiomeVisuals()
		{
			/*if (ZoneVolcano)
				player.ManageSpecialBiomeVisuals("Sierra:Volcano", true, player.Center);
			else
				player.ManageSpecialBiomeVisuals("Sierra:Volcano", false, player.Center);
			*/

		}
		 public override void UpdateBadLifeRegen()
        {
            if (ackFire)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
				/*if (!Main.expertMode)
					player.Hurt(PlayerDeathReason.LegacyEmpty(), 10+(player.statDefense/2), 0);
				else
					player.Hurt(PlayerDeathReason.LegacyEmpty(), 10+(int)(player.statDefense*0.75), 0);*/
				
            }
        }
		public override void PostUpdate()
        {
			debuffTimer++;
			if (debuffTimer % 20 == 0 && ackFire)
			{
				CombatText.NewText(new Microsoft.Xna.Framework.Rectangle((int) player.position.X, (int) player.position.Y, player.width, player.height), Color.Red, "10", true, false);
				player.statLife -= 10;
			}
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (boom)
			{
				for (int i = 0; i < 360; i += 5)
				{
					Vector2 vec = Vector2.Transform(new Vector2(-10, 0), Matrix.CreateRotationZ(MathHelper.ToRadians(i)));
					vec.Normalize();
					int num622 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 258, 0f, 0f, 258, new Color(53f, 67f, 253f), 2f);
					Main.dust[num622].velocity += (vec *2f);
					
				}
				for (int i = 0; i < Main.npc.Length; i++)
				{
					if (player.Distance(Main.npc[i].Center) < 100)
						Main.npc[i].StrikeNPC(50, 0f, 0, false, false, false);
				}
			}
		}
		public override void PreUpdateBuffs()
        {
            if (FireWarrior)
            {
                player.statDefense += 1;
				player.meleeCrit += 2;
			}
			if (PossessiveOne)
            {
                player.statLifeMax2 += 40;
			}
		}
    }
}