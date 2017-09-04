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
        public override void ResetEffects()
        {
            
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
    }
}