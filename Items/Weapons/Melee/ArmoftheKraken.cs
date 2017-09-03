using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LegendMod.Items
{
    public class ArmoftheKraken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arm of the Kraken");
            Tooltip.SetDefault("Ripped from the Kraken's body. It's so gross, you don't want to touch it...");
        }
        public override void SetDefaults()
        {
            item.damage = 125;
            item.melee = true;
            item.width = 90;
            item.height = 90;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = 24000;
            item.rare = 8;
            item.UseSound = SoundID.NPCDeath1;
            item.autoReuse = true;
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 300);
        }
    }
}