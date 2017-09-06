using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Sierra.Items.Weapons.Melee
{
    public class MagmaBat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Bat");
        }
        public override void SetDefaults()
        {
            item.damage = 55;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = 20000;
            item.rare = 6;
            item.UseSound = SoundID.Item18;
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