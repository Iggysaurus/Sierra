using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Sierra.Buffs
{
    public class BadFire : ModBuff
    {
        public override void SetDefaults()
        {
			DisplayName.SetDefault("Burning up");
			Description.SetDefault("you're dying");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;

            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer p = player.GetModPlayer<MyPlayer>(mod);
            p.ackFire = true;
        }
    }
}
