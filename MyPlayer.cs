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
		public bool ZoneVolcano;
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
    }
}