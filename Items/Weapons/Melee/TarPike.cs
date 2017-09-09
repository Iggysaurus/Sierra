using Sierra.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Melee
{
    public class TarPike : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDafault("Tar Pike");
            Tooltip.SetDefault("stabby stabby iggy");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.useStyle = 5;
            item.useAnimation = 18;
            item.useTime = 20;
            item.shootSpeed = 3.7f;
            item.knockBack = 6.5f;
            item.width = 32;
            item.height = 32;
            item.scale = 1f;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType<TarPikeProjectile>();
            item.value = 1000;
            item.noMelee = true; 
            item.noUseGraphic = true; 
            item.melee = true;
            item.autoReuse = true; 
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1; 
        }
    }
}
