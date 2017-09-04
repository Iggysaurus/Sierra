using System.IO;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace Sierra
{
    public class SierraWorld : ModWorld
    {
		public static int volcanoTiles = 0;
		
		public override void ResetNearbyTileEffects()
		{
			MyPlayer modPlayer = Main.LocalPlayer.GetModPlayer<MyPlayer>(mod);
			volcanoTiles = 0;
		}
		public override void TileCountsAvailable(int[] tileCounts)
		{
			volcanoTiles = tileCounts[mod.TileType("VolcanoStone")] + tileCounts[mod.TileType("MoltenOre")] ;
		}
    }

}	