using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;

namespace Sierra
{
	class Sierra : Mod
	{
		public Sierra()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	    
		public static bool NoInvasion(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.invasion && ((!Main.pumpkinMoon && !Main.snowMoon) || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) && (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);
		}

		public static bool NoBiome(NPCSpawnInfo spawnInfo)
		{
			Player player = spawnInfo.player;
			return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
		}

		public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;
		}

		public static bool NoZone(NPCSpawnInfo spawnInfo)
		{
			return NoZoneAllowWater(spawnInfo) && !spawnInfo.water;
		}

		public static bool NormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return !spawnInfo.playerInTown && NoInvasion(spawnInfo);
		}

		public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZone(spawnInfo);
		}

		public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);
		}

		public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo)
		{
			return NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);
		}
		
		public override void UpdateMusic(ref int music)
		{
			if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneVolcano && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Track2");
            }
        }
	
	}
}
