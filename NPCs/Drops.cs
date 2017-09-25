using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.NPCs
{
	public class Drops : GlobalNPC
	{
		
		public override void NPCLoot(NPC npc)  
        {
			
			Player player = Main.LocalPlayer;
			if (npc.type == 1 || npc.type == -3 || npc.type == -6 || npc.type == -7 || npc.type == -8 || npc.type == -9)
			{
				if (Main.rand.Next(1000) == 1)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeLauncher"), 1);
			}
			if (npc.type == -4 && Main.rand.Next(50) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SlimeLauncher"), 1);
			}
			
			if (npc.type == 327 && Main.rand.Next(1) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PumpkinStabber"), 1);
			}
			if (npc.type == 50 || npc.type == 4 || npc.type == 266)
			{
				if (Main.rand.Next(100) == 1)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PossessiveOrb"), 1);
			}

        }
	}
}