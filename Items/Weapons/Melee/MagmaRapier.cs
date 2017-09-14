using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Sierra.Items.Weapons.Melee
{
    public class MagmaRapier : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Rapier");
        }
        public override void SetDefaults()
        {
            item.damage = 47;
            item.melee = true;
            item.width = 38;
            item.height = 38;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 2000;
            item.rare = 6;
            item.UseSound = SoundID.Item18;
            item.shootSpeed = 8f;
			item.shoot = mod.ProjectileType("MagmaProj");
			item.autoReuse = true;
        }

		
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(player.position, player.width,player.height, 6);
			}
		}

	}
}