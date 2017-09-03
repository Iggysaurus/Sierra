using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LegendMod.Items
{
    public class Starfury : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Starfury)
            {
                item.damage = 31;       //Changed original Starfury's damage to 31!
            }
        }
    }
}