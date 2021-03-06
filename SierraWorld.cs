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

        public void PlaceVolcano(int x, int y)
        {
			//some notes:
			//It is the same on every worldsize. This will be fixed.
			//It doesn't merge with the ground well AT ALL. This will also be fixed.
			//The elevation is kinda fucked.
			//Most of the values are arbituary.
			//The code does need to be cleaned up. I'll do that in the final version.
			//Most of the methods I use are in WorldMethods. Its a file i copypaste in any worldgen project I do, so it may have some unused methods.
			
			
			//basic land of the area.
	
			for (int depth = 0; depth < 100; depth++)
			{
				if (Main.rand.Next(6) == 1)
				{
				WorldMethods.TileRunner(x, y + depth, (double)125 + Main.rand.Next(75), 1, mod.TileType("VolcanoTile"), false, 0f, 0f, true, true); //improve basic shape later
				}
			}
			
			//random bits of lava above ground, that fall. Despite not being the "prettiest" method, it probably looks and works the best.
			for (int r = 0; r < 250; r++)
			{
				Tile tile = Main.tile[x + Main.rand.Next(-75, 75), y - Main.rand.Next(10,85)];
				tile.liquid = 255;
				tile.lava(true);
			}
			//A line of consecutive "spikes" along the ground.
			for (int k = x - 85; k < x + 85; k++)
			{
			WorldMethods.CragSpike(k, (int)(y - Main.rand.Next(10,28)), 1, 30, (ushort)mod.TileType("VolcanoStone"), (float)Main.rand.Next(2, 6), (float)Main.rand.Next(2, 6));
			}
			
			//the main volcano
			WorldMethods.MainVolcano(x, (int)(y - Main.rand.Next(70,90)), 3, 130, (ushort)mod.TileType("VolcanoStone"), (float)(Main.rand.Next(400, 600) / 100), (float)(Main.rand.Next(400, 600) / 100));
			
			//digs the tunnel down the middle
			for (int j = y - 100; j < y + 20; j++)
			{
				WorldGen.digTunnel(x, j, 0, 0, 8, (int)(5 + (Math.Sqrt((j + 100) - y) / 1.5f)), false);
				
			}
			//giant gaping hole you see at the bottom.
			WorldMethods.RoundHole(x, y + 30, 17, 7, 10, true);
			
			//more random lava bits.
			for (int r = 0; r < 2000; r++)
			{
				Tile tile = Main.tile[x + Main.rand.Next(-30, 30), y + Main.rand.Next(-20,45)];
				tile.liquid = 255;
				tile.lava(true);
			}
			
			//generates the ore
			for (int OreGen = 0; OreGen < 100; OreGen++)
				{ 
					int orex= x + Main.rand.Next(-75, 75);
					int orey = y + Main.rand.Next(-20, 300);
					if (Main.tile[orex, orey].type == mod.TileType("VolcanoStone"))
					{
						WorldGen.TileRunner(orex, orey, (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), mod.TileType("MoltenOre"), false, 0f, 0f, false, true);
					}				   // A = x, B = y.
				}
				
				//Turns nearby water into lava.
			for (int LiquidX = -110; LiquidX < 110; LiquidX++)
			{
				for (int LiquidY = -20; LiquidY < 150; LiquidY++)
			{
				Tile tile = Main.tile[x + LiquidX, y + LiquidY];
				if (tile.liquid > 0)
				{
				tile.lava(true);
				}
			}
			}
		}
		
        static bool VolcanoPlacement(int x, int y)
        {
            if (x > ((Main.maxTilesX / 2) - 200) && x < ((Main.maxTilesX / 2) + 200))
            {
                return false;
            }
			if (x < 500 || x > Main.maxTilesX - 500)
			{
				return false;
			}
            for (int i = x - 32; i < x + 32; i++)
            {
                for (int j = y - 32; j < y + 32; j++)
                {
                    int[] TileArray = { TileID.BlueDungeonBrick, TileID.GreenDungeonBrick, TileID.PinkDungeonBrick, TileID.Cloud, TileID.RainCloud, 147, 53, 40, 199, 23, 25, 203 };
                    for (int ohgodilovememes = 0; ohgodilovememes < TileArray.Length - 1; ohgodilovememes++)
                    {
                        if (Main.tile[i, j].type == (ushort)TileArray[ohgodilovememes])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
             public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                // Shinies pass removed by some other mod.
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Volcano", delegate (GenerationProgress progress)
            {
                progress.Message = "Volling canoes";
                int X = 1;
                int Y = 1;
                float widthScale = (Main.maxTilesX / 4200f);
                int numberToGenerate = 1;
                for (int k = 0; k < numberToGenerate; k++)
                {
                    bool placement = false;
                    bool placed = false;
                    while (!placed)
                    {
                        bool success = false;
                        int attempts = 0;
                        while (!success)
                        {
                            attempts++;
                            if (attempts > 1000)
                            {
                                success = true;
                                continue;
                            }
                            int i = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                            if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50)
                            {
                                int j = 0;
                                while (!Main.tile[i, j].active() && (double)j < Main.worldSurface)
                                {
                                    j++;
                                }
                                if (Main.tile[i, j].type == 60 || Main.tile[i, j].type == 0)
                                {
                                    j--;
                                    if (j > 150)
                                    {
                                        placement = VolcanoPlacement(i, j);
                                        if (placement)
                                        {
                                            X = i;
										//	progress.Message = "BAZINGA";
                                            Y = j;
                                            PlaceVolcano(i, j);
                                            success = true;
                                            placed = true;
                                            continue;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
				
            }));
			
			
        }
        
    }
}

